using CloudinaryDotNet;
using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Categories.GetAll;
using LibraRestaurant.Application.Queries.Categories.GetCategoryById;
using LibraRestaurant.Application.Queries.Categories.GetCurrencyById;
using LibraRestaurant.Application.Queries.Currencies.GetAll;
using LibraRestaurant.Application.Queries.Currencies.GetCurrencyById;
using LibraRestaurant.Application.Queries.MenuItems.GetAll;
using LibraRestaurant.Application.Queries.MenuItems.GetById;
using LibraRestaurant.Application.Queries.Menus.GetAll;
using LibraRestaurant.Application.Queries.Menus.GetUserById;
using LibraRestaurant.Application.Queries.Orders.GetAll;
using LibraRestaurant.Application.Queries.Orders.GetOrderById;
using LibraRestaurant.Application.Queries.Stores.GetAll;
using LibraRestaurant.Application.Queries.Stores.GetStoreById;
using LibraRestaurant.Application.Queries.Users.GetAll;
using LibraRestaurant.Application.Queries.Users.GetUserById;
using LibraRestaurant.Application.Services;
using LibraRestaurant.Application.SortProviders;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Application.ViewModels.Categories;
using LibraRestaurant.Application.ViewModels.Currencies;
using LibraRestaurant.Application.ViewModels.MenuItems;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Orders;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels.Stores;
using LibraRestaurant.Application.ViewModels.Users;
using LibraRestaurant.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraRestaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IStoreService, StoreService>();

        services.AddSingleton<Cloudinary>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var cloudinaryAccount = new Account(
                configuration["CloudinaryConfiguration:CloudName"],
                configuration["CloudinaryConfiguration:ApiKey"],
                configuration["CloudinaryConfiguration:ApiSecret"]
            );
            return new Cloudinary(cloudinaryAccount);
        });

        return services;
    }

    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        // User
        services.AddScoped<IRequestHandler<GetUserByIdQuery, UserViewModel?>, GetUserByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllUsersQuery, PagedResult<UserViewModel>>, GetAllUsersQueryHandler>();

        // Item
        services.AddScoped<IRequestHandler<GetItemByIdQuery, ItemViewModel?>, GetItemByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllItemsQuery, PagedResult<ItemViewModel>>, GetAllItemsQueryHandler>();

        // Menu
        services.AddScoped<IRequestHandler<GetMenuByIdQuery, MenuViewModel?>, GetMenuByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllMenusQuery, PagedResult<MenuViewModel>>, GetAllMenusQueryHandler>();

        // Category
        services.AddScoped<IRequestHandler<GetCategoryByIdQuery, CategoryViewModel?>, GetCategoryByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllCategoriesQuery, PagedResult<CategoryViewModel>>, GetAllCategoriesQueryHandler>();

        // Currency
        services.AddScoped<IRequestHandler<GetCurrencyByIdQuery, CurrencyViewModel?>, GetCurrencyByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllCurrenciesQuery, PagedResult<CurrencyViewModel>>, GetAllCurrenciesQueryHandler>();

        // Order
        services.AddScoped<IRequestHandler<GetOrderByIdQuery, OrderViewModel?>, GetOrderByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllOrdersQuery, PagedResult<OrderViewModel>>, GetAllOrdersQueryHandler>();

        // Store
        services.AddScoped<IRequestHandler<GetStoreByIdQuery, StoreViewModel?>, GetStoreByIdQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllStoresQuery, PagedResult<StoreViewModel>>, GetAllStoresQueryHandler>();

        return services;
    }

    public static IServiceCollection AddSortProviders(this IServiceCollection services)
    {
        services.AddScoped<ISortingExpressionProvider<UserViewModel, User>, UserViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<ItemViewModel, MenuItem>, ItemViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<MenuViewModel, Menu>, MenuViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<CategoryViewModel, Category>, CategoryViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<CurrencyViewModel, Currency>, CurrencyViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<OrderViewModel, OrderHeader>, OrderViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<StoreViewModel, Store>, StoreViewModelSortProvider>();

        return services;
    }
}