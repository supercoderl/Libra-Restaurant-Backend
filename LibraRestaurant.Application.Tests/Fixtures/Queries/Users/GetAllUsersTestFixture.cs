using System;
using LibraRestaurant.Application.Queries.Users.GetAll;
using LibraRestaurant.Application.SortProviders;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace LibraRestaurant.Application.Tests.Fixtures.Queries.Users;

public sealed class GetAllUsersTestFixture : QueryHandlerBaseFixture
{
    private IUserRepository UserRepository { get; }
    public GetAllUsersQueryHandler Handler { get; }
    public Guid ExistingUserId { get; } = Guid.NewGuid();

    public GetAllUsersTestFixture()
    {
        UserRepository = Substitute.For<IUserRepository>();
        var sortingProvider = new UserViewModelSortProvider();

        Handler = new GetAllUsersQueryHandler(UserRepository, sortingProvider);
    }

    public User SetupUserAsync()
    {
        var user = new User(
            ExistingUserId,
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "09091234567",
            "Password",
            DateTime.Now);

        var query = new[] { user }.BuildMock();

        UserRepository.GetAllNoTracking().Returns(query);

        return user;
    }

    public void SetupDeletedUserAsync()
    {
        var user = new User(
            ExistingUserId,
            "max@mustermann.com",
            "Max",
            "Mustermann",
            "09091234567",
            "Password",
            DateTime.Now);

        user.Delete();

        var query = new[] { user }.BuildMock();

        UserRepository.GetAllNoTracking().Returns(query);
    }
}