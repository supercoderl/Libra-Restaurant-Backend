using System;
using System.Net.Http;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Constants;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Infrastructure.Database;
using LibraRestaurant.IntegrationTests.Infrastructure;
using LibraRestaurant.IntegrationTests.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LibraRestaurant.IntegrationTests.Fixtures;

public class TestFixtureBase : IAsyncLifetime
{
    public HttpClient ServerClient { get; }
    protected LibraRestaurantWebApplicationFactory Factory { get; }

    public TestFixtureBase(bool useTestAuthentication = true)
    {
        Factory = new LibraRestaurantWebApplicationFactory(
            RegisterCustomServicesHandler,
            useTestAuthentication,
            AccessorFixture.TestRunDbName);

        ServerClient = Factory.CreateClient();
        ServerClient.Timeout = TimeSpan.FromMinutes(5);
    }

    protected virtual void SeedTestData(ApplicationDbContext context)
    {
    }

    private async Task PrepareDatabaseAsync()
    {
        await Factory.RespawnDatabaseAsync();

        using var scope = Factory.Services.CreateScope();
        await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Users.Add(new User(
            Ids.Seed.UserId,
            "admin@email.com",
            "Admin",
            "User",
            "$2a$12$Blal/uiFIJdYsCLTMUik/egLbfg3XhbnxBC6Sb5IKz2ZYhiU/MzL2",
            UserRole.Admin));

        dbContext.Users.Add(new User(
            TestAuthenticationOptions.TestUserId,
            TestAuthenticationOptions.Email,
            TestAuthenticationOptions.FirstName,
            TestAuthenticationOptions.LastName,
            TestAuthenticationOptions.Password,
            UserRole.Admin));

        SeedTestData(dbContext);
        await dbContext.SaveChangesAsync();
    }

    protected virtual void RegisterCustomServicesHandler(
        IServiceCollection services,
        ServiceProvider serviceProvider,
        IServiceProvider scopedServices)
    {
    }

    public async Task InitializeAsync()
    {
        await PrepareDatabaseAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}