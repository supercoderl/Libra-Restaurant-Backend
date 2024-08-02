using System;
using LibraRestaurant.Domain.Commands.Users.UpdateUser;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using NSubstitute;

namespace LibraRestaurant.Domain.Tests.CommandHandler.User.UpdateUser;

public sealed class UpdateItemCommandTestFixture : CommandHandlerFixtureBase
{
    public UpdateUserCommandHandler CommandHandler { get; }
    public IUserRepository UserRepository { get; }

    public UpdateItemCommandTestFixture()
    {
        UserRepository = Substitute.For<IUserRepository>();

        CommandHandler = new UpdateUserCommandHandler(
            Bus,
            UnitOfWork,
            NotificationHandler,
            UserRepository,
            User);
    }

    public Entities.User SetupUser()
    {
        var user = new Entities.User(
            Guid.NewGuid(),
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "09091234567",
            "Password",
            DateTime.Now);

        UserRepository
            .GetByIdAsync(Arg.Is<Guid>(y => y == user.Id))
            .Returns(user);

        return user;
    }

    public void SetupCurrentUser(Guid userId)
    {
        User.GetUserId().Returns(userId);
    }
}