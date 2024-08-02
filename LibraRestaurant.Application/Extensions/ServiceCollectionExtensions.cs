using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.MenuItems.GetAll;
using LibraRestaurant.Application.Queries.MenuItems.GetById;
using LibraRestaurant.Application.Queries.Menus.GetAll;
using LibraRestaurant.Application.Queries.Menus.GetUserById;
using LibraRestaurant.Application.Queries.Users.GetAll;
using LibraRestaurant.Application.Queries.Users.GetUserById;
using LibraRestaurant.Application.Services;
using LibraRestaurant.Application.SortProviders;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Application.ViewModels.MenuItems;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels.Users;
using LibraRestaurant.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraRestaurant.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuItemService, MenuItemService>();

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

        return services;
    }

    public static IServiceCollection AddSortProviders(this IServiceCollection services)
    {
        services.AddScoped<ISortingExpressionProvider<UserViewModel, User>, UserViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<ItemViewModel, MenuItem>, ItemViewModelSortProvider>();
        services.AddScoped<ISortingExpressionProvider<MenuViewModel, Menu>, MenuViewModelSortProvider>();

        return services;
    }
}