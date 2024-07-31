using System;
using System.Collections.Generic;
using LibraRestaurant.Application.gRPC;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Interfaces.Repositories;
using MockQueryable.NSubstitute;
using NSubstitute;

namespace LibraRestaurant.gRPC.Tests.Fixtures;

public sealed class UserTestFixture
{
    private IUserRepository UserRepository { get; } = Substitute.For<IUserRepository>();

    public UsersApiImplementation UsersApiImplementation { get; }

    public IEnumerable<User> ExistingUsers { get; }

    public UserTestFixture()
    {
        ExistingUsers = new List<User>
        {
            new(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "test@test.de",
                "Test First Name",
                "Test Last Name",
                "Test Password",
                UserRole.User),
            new(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "email@Email.de",
                "Email First Name",
                "Email Last Name",
                "Email Password",
                UserRole.Admin),
            new(
                Guid.NewGuid(),
                Guid.NewGuid(),
                "user@user.de",
                "User First Name",
                "User Last Name",
                "User Password",
                UserRole.User)
        };

        var queryable = ExistingUsers.BuildMock();

        UserRepository.GetAllNoTracking().Returns(queryable);

        UsersApiImplementation = new UsersApiImplementation(UserRepository);
    }
}