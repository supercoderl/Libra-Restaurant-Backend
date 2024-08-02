using System;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Commands.Users.DeleteUser;
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Shared.Events.User;
using Xunit;

namespace LibraRestaurant.Domain.Tests.CommandHandler.User.DeleteUser;

public sealed class DeleteItemCommandHandlerTests
{
    private readonly DeleteItemCommandTestFixture _fixture = new();

    [Fact]
    public async Task Should_Delete_User()
    {
        var user = _fixture.SetupUser();

        var command = new DeleteUserCommand(user.Id);

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoDomainNotification()
            .VerifyCommit()
            .VerifyRaisedEvent<UserDeletedEvent>(x => x.AggregateId == user.Id);
    }

    [Fact]
    public async Task Should_Not_Delete_Non_Existing_User()
    {
        _fixture.SetupUser();

        var command = new DeleteUserCommand(Guid.NewGuid());

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoCommit()
            .VerifyNoRaisedEvent<UserDeletedEvent>()
            .VerifyAnyDomainNotification()
            .VerifyExistingNotification(
                ErrorCodes.ObjectNotFound,
                $"There is no user with Id {command.UserId}");
    }

    [Fact]
    public async Task Should_Not_Delete_User_Insufficient_Permissions()
    {
        var user = _fixture.SetupUser();

        var command = new DeleteUserCommand(user.Id);

        await _fixture.CommandHandler.Handle(command, default);

        _fixture
            .VerifyNoCommit()
            .VerifyNoRaisedEvent<UserDeletedEvent>()
            .VerifyAnyDomainNotification()
            .VerifyExistingNotification(
                ErrorCodes.InsufficientPermissions,
                $"No permission to delete user {command.UserId}");
    }
}