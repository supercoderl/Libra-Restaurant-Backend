using LibraRestaurant.gRPC.Contexts;
using LibraRestaurant.gRPC.Interfaces;
using LibraRestaurant.gRPC.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibraRestaurant.Proto.Users;
using LibraRestaurant.Proto.MenuItems;
using LibraRestaurant.Proto.Menus;
using LibraRestaurant.Proto.Categories;
using LibraRestaurant.Proto.Currencies;
using Grpc.Net.Client;
using LibraRestaurant.Proto.Orders;
using LibraRestaurant.Proto.Stores;
using LibraRestaurant.Proto.Reservations;
using LibraRestaurant.Proto.PaymentMethods;
using LibraRestaurant.Proto.Cities;
using LibraRestaurant.Proto.Districts;
using LibraRestaurant.Proto.Wards;
using LibraRestaurant.Proto.PaymentHistories;

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

        var ordersClient = new OrdersApi.OrdersApiClient(channel);
        services.AddSingleton(ordersClient);

        var storesClient = new StoresApi.StoresApiClient(channel);
        services.AddSingleton(storesClient);

        var reservationsClient = new ReservationsApi.ReservationsApiClient(channel);
        services.AddSingleton(reservationsClient);

        var orderLinesClient = new ReservationsApi.ReservationsApiClient(channel);
        services.AddSingleton(orderLinesClient);

        var paymentMethodsClient = new PaymentMethodsApi.PaymentMethodsApiClient(channel);
        services.AddSingleton(paymentMethodsClient);

        var citiesClient = new CitiesApi.CitiesApiClient(channel);
        services.AddSingleton(citiesClient);

        var districtsClient = new DistrictsApi.DistrictsApiClient(channel);
        services.AddSingleton(districtsClient);

        var wardsClient = new WardsApi.WardsApiClient(channel);
        services.AddSingleton(wardsClient);

        var paymentHistoriesClient = new PaymentHistoriesApi.PaymentHistoriesApiClient(channel);
        services.AddSingleton(paymentHistoriesClient);

        services.AddSingleton<IUsersContext, UsersContext>();
        services.AddSingleton<IMenuItemsContext, MenuItemsContext>();
        services.AddSingleton<IMenusContext, MenusContext>();
        services.AddSingleton<ICategoriesContext, CategoriesContext>();
        services.AddSingleton<ICurrenciesContext, CurrenciesContext>();
        services.AddSingleton<IOrdersContext, OrdersContext>();
        services.AddSingleton<IStoresContext, StoresContext>();
        services.AddSingleton<IReservationsContext, ReservationsContext>();
        services.AddSingleton<IOrderLinesContext, OrderLinesContext>();
        services.AddSingleton<IPaymentMethodsContext, PaymentMethodsContext>();
        services.AddSingleton<ICitiesContext, CitiesContext>();
        services.AddSingleton<IDistrictsContext, DistrictsContext>();
        services.AddSingleton<IWardsContext, WardsContext>();
        services.AddSingleton<IPaymentHistoriesContext, PaymentHistoriesContext>();

        return services;
    }
}