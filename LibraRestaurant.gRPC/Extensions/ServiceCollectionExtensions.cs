using LibraRestaurant.gRPC.Contexts;
using LibraRestaurant.gRPC.Interfaces;
using LibraRestaurant.gRPC.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraRestaurant.gRPC.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcClient(
        this IServiceCollection services,
        IConfiguration configuration,
        string configSectionKey = "gRPC")
    {
        var settings = new GRPCSettings();
        configuration.Bind(configSectionKey, settings);

        return AddGrpcClient(services, settings);
    }

    public static IServiceCollection AddGrpcClient(this IServiceCollection services, GRPCSettings settings)
    {
        if (!string.IsNullOrWhiteSpace(settings.LibraRestaurantUrl))
        {
            services.AddLibraRestaurantGrpcClient(settings.LibraRestaurantUrl);
        }

        services.AddSingleton<ILibraRestaurant, LibraRestaurant>();

        return services;
    }

    public static IServiceCollection AddLibraRestaurantGrpcClient(
        this IServiceCollection services,
        string gRPCUrl)
    {
        if (string.IsNullOrWhiteSpace(gRPCUrl))
        {
            return services;
        }

        var channel = GrpcChannel.ForAddress(gRPCUrl);

        var usersClient = new UsersApi.UsersApiClient(channel);
        services.AddSingleton(usersClient);

        var itemsClient = new ItemsApi.ItemsApiClient(channel);
        services.AddSingleton(itemsClient);

        var menusClient = new MenusApi.MenusApiClient(channel);
        services.AddSingleton(menusClient);

        var categoriesClient = new CategoriesApi.CategoriesApiClient(channel);
        services.AddSingleton(categoriesClient);

        var currenciesClient = new CurrenciesApi.CurrenciesApiClient(channel);
        services.AddSingleton(currenciesClient);

        services.AddSingleton<IUsersContext, UsersContext>();
        services.AddSingleton<IMenuItemsContext, MenuItemsContext>();
        services.AddSingleton<IMenusContext, MenusContext>();
        services.AddSingleton<ICategoriesContext, CategoriesContext>();
        services.AddSingleton<ICurrenciesContext, CurrenciesContext>();

        return services;
    }
}