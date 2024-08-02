using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Shared.Events.User;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace LibraRestaurant.Domain.Commands.Users.CreateUser;

public sealed class CreateUserCommandHandler : CommandHandlerBase,
    IRequestHandler<CreateUserCommand>
{
    private readonly IUser _user;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(
        IMediatorHandler bus,
        IUnitOfWork unitOfWork,
        INotificationHandler<DomainNotification> notifications,
        IUserRepository userRepository,
        IUser user) : base(bus, unitOfWork, notifications)
    {
        _userRepository = userRepository;
        _user = user;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (!await TestValidityAsync(request))
        {
            return;
        }

        var currentUser = await _userRepository.GetByIdAsync(_user.GetUserId());

        if (currentUser is null)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    "You are not allowed to create users",
                    ErrorCodes.InsufficientPermissions));
            return;
        }

        var existingUser = await _userRepository.GetByIdAsync(request.UserId);

        if (existingUser is not null)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    $"There is already a user with Id {request.UserId}",
                    DomainErrorCodes.User.AlreadyExists));
            return;
        }

        existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser is not null)
        {
            await NotifyAsync(
                new DomainNotification(
                    request.MessageType,
                    $"There is already a user with email {request.Email}",
                    DomainErrorCodes.User.AlreadyExists));
            return;
        }

        var passwordHash = BC.HashPassword(request.Password);

        var user = new User(
            request.UserId,
            request.Email,
            request.FirstName,
            request.LastName,
            request.Mobile,
            passwordHash,
            System.DateTime.Now);

        _userRepository.Add(user);

        if (await CommitAsync())
        {
            await Bus.RaiseEventAsync(new UserCreatedEvent(user.Id));
        }
    }
}