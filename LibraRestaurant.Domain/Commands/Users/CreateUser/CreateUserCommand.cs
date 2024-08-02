using System;

namespace LibraRestaurant.Domain.Commands.Users.CreateUser;

public sealed class CreateUserCommand : CommandBase
{
    private static readonly CreateUserCommandValidation s_validation = new();

    public Guid UserId { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Mobile { get; }
    public string Password { get; }

    public CreateUserCommand(
        Guid userId,
        string email,
        string firstName,
        string lastName,
        string mobile,
        string password) : base(userId)
    {
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
        Password = password;
    }

    public override bool IsValid()
    {
        ValidationResult = s_validation.Validate(this);
        return ValidationResult.IsValid;
    }
}