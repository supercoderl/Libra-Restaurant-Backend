using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace LibraRestaurant.Domain.Commands.Employees.LoginEmployee;

public sealed class LoginEmployeeCommandHandler : CommandHandlerBase,
    IRequestHandler<LoginEmployeeCommand, string>
{
    private const double _expiryDurationMinutes = 60;
    private readonly TokenSettings _tokenSettings;

    private readonly IEmployeeRepository _employeeRepository;

    public LoginEmployeeCommandHandler(
        IMediatorHandler bus,
        IUnitOfWork unitOfWork,
        INotificationHandler<DomainNotification> notifications,
        IEmployeeRepository employeeRepository,
        IOptions<TokenSettings> tokenSettings) : base(bus, unitOfWork, notifications)
    {
        _employeeRepository = employeeRepository;
        _tokenSettings = tokenSettings.Value;
    }

    public async Task<string> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (!await TestValidityAsync(request))
        {
            return "";
        }

        var employee = await _employeeRepository.GetByEmailAsync(request.Email);

        if (employee is null)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    $"There is no employee with email {request.Email}",
                    ErrorCodes.ObjectNotFound));

            return "";
        }

        var passwordVerified = BC.Verify(request.Password, employee.Password);

        if (!passwordVerified)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    "The password is incorrect",
                    DomainErrorCodes.Employee.PasswordIncorrect));

            return "";
        }

        employee.SetActive();
        employee.SetLastLoggedinDate(DateTimeOffset.Now);

        if (!await CommitAsync())
        {
            return "";
        }

        return BuildToken(
            employee,
            _tokenSettings);
    }

    private static string BuildToken(Employee employee, TokenSettings tokenSettings)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim(ClaimTypes.MobilePhone, employee.Mobile),
            new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
            new Claim(ClaimTypes.Name, employee.FullName)
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(tokenSettings.Secret));

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new JwtSecurityToken(
            tokenSettings.Issuer,
            tokenSettings.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(_expiryDurationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}