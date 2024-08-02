using System;
using LibraRestaurant.Domain.Commands.Users.ChangePassword;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using NSubstitute;
using BC = BCrypt.Net.BCrypt;

namespace LibraRestaurant.Domain.Tests.CommandHandler.User.ChangePassword;

public sealed class ChangePasswordCommandTestFixture : CommandHandlerFixtureBase
{
    public ChangePasswordCommandHandler CommandHandler { get; }
    private IUserRepository UserRepository { get; }

    public ChangePasswordCommandTestFixture()
    {
        UserRepository = Substitute.For<IUserRepository>();

        CommandHandler = new ChangePasswordCommandHandler(
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
            BC.HashPassword("z8]tnayvd5FNLU9:]AQm"),
            DateTime.Now);

        User.GetUserId().Returns(user.Id);

        UserRepository
            .GetByIdAsync(Arg.Is<Guid>(y => y == user.Id))
            .Returns(user);

        return user;
    }

    public Guid SetupMissingUser()
    {
        var id = Guid.NewGuid();
        User.GetUserId().Returns(id);
        return id;
    }
}