using System;
using LibraRestaurant.Domain.Enums;

namespace LibraRestaurant.Domain.Commands.Users.UpdateUser;

public sealed class UpdateUserCommand : CommandBase
{
    private static readonly UpdateUserCommandValidation s_validation = new();

    public Guid UserId { get; }
    public string Email { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Mobile { get; }

    public UpdateUserCommand(
        Guid userId,
        string email,
        string firstName,
        string lastName,
        string mobile) : base(userId)
    {
        UserId = userId;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
    }

    public override bool IsValid()
    {
        ValidationResult = s_validation.Validate(this);
        return ValidationResult.IsValid;
    }
}