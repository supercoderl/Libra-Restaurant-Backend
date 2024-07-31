using System;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using NSubstitute;

namespace LibraRestaurant.Domain.Tests.CommandHandler.User.CreateUser;

public sealed class CreateUserCommandTestFixture : CommandHandlerFixtureBase
{
    public CreateUserCommandHandler CommandHandler { get; }
    public IUserRepository UserRepository { get; }

    public CreateUserCommandTestFixture()
    {
        UserRepository = Substitute.For<IUserRepository>();

        CommandHandler = new CreateUserCommandHandler(
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
            "Password",
            UserRole.User);

        UserRepository
            .GetByIdAsync(Arg.Is<Guid>(y => y == user.Id))
            .Returns(user);

        return user;
    }

    public void SetupCurrentUser()
    {
        var userId = Guid.NewGuid();

        User.GetUserId().Returns(userId);

        UserRepository
            .GetByIdAsync(Arg.Is<Guid>(y => y == userId))
            .Returns(new Entities.User(
                userId,
                "some email",
                "some first name",
                "some last name",
                "some password",
                UserRole.Admin));
    }
}