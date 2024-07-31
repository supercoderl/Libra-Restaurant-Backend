using System;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Shared.Events.User;
using NSubstitute;
using Xunit;

namespace LibraRestaurant.Domain.Tests.CommandHandler.User.CreateUser;

public sealed class CreateUserCommandHandlerTests
{
    private readonly CreateUserCommandTestFixture _fixture = new();

    [Fact]
    public async Task Should_Create_User()
    {
        _fixture.SetupCurrentUser();

        var user = _fixture.SetupUser();

        var command = new CreateUserCommand(
            Guid.NewGuid(),
            "test@email.com",
            "Test",
            "Email",
            "Po=PF]PC6t.?8?ks)A6W");

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoDomainNotification()
            .VerifyCommit()
            .VerifyRaisedEvent<UserCreatedEvent>(x => x.AggregateId == command.UserId);
    }

    [Fact]
    public async Task Should_Not_Create_Already_Existing_User()
    {
        _fixture.SetupCurrentUser();

        var user = _fixture.SetupUser();

        var command = new CreateUserCommand(
            user.Id,
            "test@email.com",
            "Test",
            "Email",
            "Po=PF]PC6t.?8?ks)A6W");

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoCommit()
            .VerifyNoRaisedEvent<UserCreatedEvent>()
            .VerifyAnyDomainNotification()
            .VerifyExistingNotification(
                DomainErrorCodes.User.AlreadyExists,
                $"There is already a user with Id {command.UserId}");
    }

    [Fact]
    public async Task Should_Not_Create_Already_Existing_Email()
    {
        _fixture.SetupCurrentUser();

        _fixture.UserRepository
            .GetByEmailAsync(Arg.Is<string>(y => y == "test@email.com"))
            .Returns(new Entities.User(
                Guid.NewGuid(),
                "max@mustermann.com",
                "Max",
                "Mustermann",
                "Password",
                UserRole.User));

        var command = new CreateUserCommand(
            Guid.NewGuid(),
            "test@email.com",
            "Test",
            "Email",
            "Po=PF]PC6t.?8?ks)A6W");

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoCommit()
            .VerifyNoRaisedEvent<UserCreatedEvent>()
            .VerifyAnyDomainNotification()
            .VerifyExistingNotification(
                DomainErrorCodes.User.AlreadyExists,
                $"There is already a user with email {command.Email}");
    }

    [Fact]
    public async Task Should_Not_Create_User_Insufficient_Permissions()
    {
        _fixture.SetupUser();

        var command = new CreateUserCommand(
            Guid.NewGuid(),
            "test@email.com",
            "Test",
            "Email",
            "Po=PF]PC6t.?8?ks)A6W");

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoCommit()
            .VerifyNoRaisedEvent<UserCreatedEvent>()
            .VerifyAnyDomainNotification()
            .VerifyExistingNotification(
                ErrorCodes.InsufficientPermissions,
                "You are not allowed to create users");
    }
}