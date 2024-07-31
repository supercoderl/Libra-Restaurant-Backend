using System;
using System.Linq;
using LibraRestaurant.Application.Queries.Users.GetUserById;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace LibraRestaurant.Application.Tests.Fixtures.Queries.Users;

public sealed class GetUserByIdTestFixture : QueryHandlerBaseFixture
{
    private IUserRepository UserRepository { get; }
    public GetUserByIdQueryHandler Handler { get; }
    public Guid ExistingUserId { get; } = Guid.NewGuid();

    public GetUserByIdTestFixture()
    {
        UserRepository = Substitute.For<IUserRepository>();

        Handler = new GetUserByIdQueryHandler(UserRepository, Bus);
    }

    public void SetupUserAsync()
    {
        var user = new User(
            ExistingUserId,
            Guid.NewGuid(),
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "Password",
            UserRole.User);

        UserRepository.GetByIdAsync(Arg.Is<Guid>(y => y == ExistingUserId)).Returns(user);
    }

    public void SetupDeletedUserAsync()
    {
        var user = new User(
            ExistingUserId,
            Guid.NewGuid(),
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "Password",
            UserRole.User);

        user.Delete();

        var query = new[] { user }.AsQueryable().BuildMock();

        UserRepository.GetAllNoTracking().Returns(query);
    }
}