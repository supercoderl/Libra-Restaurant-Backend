using LibraRestaurant.Domain.DomainEvents;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Infrastructure.Database;
using LibraRestaurant.Infrastructure.EventSourcing;
using LibraRestaurant.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraRestaurant.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string migrationsAssemblyName,
        string connectionStringName = "DefaultConnection")
    {
        // Add event store db context
        services.AddDbContext<EventStoreDbContext>(
            options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(connectionStringName),
                    b => b.MigrationsAssembly(migrationsAssemblyName));
            });

        services.AddDbContext<DomainNotificationStoreDbContext>(
            options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString(connectionStringName),
                    b => b.MigrationsAssembly(migrationsAssemblyName));
            });

        // Core Infra
        services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
        services.AddScoped<IEventStoreContext, EventStoreContext>();
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<IDomainEventStore, DomainEventStore>();
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICurrencyRepository, CurrencyRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IStoreRepository, StoreRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IOrderLineRepository, OrderLineRepository>();
        services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IWardRepository, WardRepository>();

        return services;
    }
}