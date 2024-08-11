
using LibraRestaurant.Domain.Commands.Categories.CreateCategory;
using LibraRestaurant.Domain.Commands.Categories.DeleteCategory;
using LibraRestaurant.Domain.Commands.Categories.UpdateCategory;
using LibraRestaurant.Domain.Commands.Currencies.CreateCurrency;
using LibraRestaurant.Domain.Commands.Currencies.DeleteCurrency;
using LibraRestaurant.Domain.Commands.Currencies.UpdateCurrency;
using LibraRestaurant.Domain.Commands.MenuItems.CreateItem;
using LibraRestaurant.Domain.Commands.MenuItems.DeleteItem;
using LibraRestaurant.Domain.Commands.MenuItems.UpdateItem;
using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Commands.Menus.DeleteMenu;
using LibraRestaurant.Domain.Commands.Menus.UpdateMenu;
using LibraRestaurant.Domain.Commands.Orders.CreateOrder;
using LibraRestaurant.Domain.Commands.Orders.DeleteOrder;
using LibraRestaurant.Domain.Commands.Orders.UpdateOrder;
using LibraRestaurant.Domain.Commands.Stores.CreateStore;
using LibraRestaurant.Domain.Commands.Stores.DeleteStore;
using LibraRestaurant.Domain.Commands.Stores.UpdateStore;
using LibraRestaurant.Domain.Commands.Users.ChangePassword;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Commands.Users.DeleteUser;
using LibraRestaurant.Domain.Commands.Users.LoginUser;
using LibraRestaurant.Domain.Commands.Users.UpdateUser;
using LibraRestaurant.Domain.EventHandler;
using LibraRestaurant.Domain.EventHandler.Fanout;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Shared.Events.Category;
using LibraRestaurant.Shared.Events.Currency;
using LibraRestaurant.Shared.Events.Menu;
using LibraRestaurant.Shared.Events.MenuItem;
using LibraRestaurant.Shared.Events.OrderHead;
using LibraRestaurant.Shared.Events.Store;
using LibraRestaurant.Shared.Events.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LibraRestaurant.Domain.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        // User
        services.AddScoped<IRequestHandler<CreateUserCommand>, CreateUserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserCommand>, UpdateUserCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
        services.AddScoped<IRequestHandler<ChangePasswordCommand>, ChangePasswordCommandHandler>();
        services.AddScoped<IRequestHandler<LoginUserCommand, string>, LoginUserCommandHandler>();

        // Item
        services.AddScoped<IRequestHandler<CreateItemCommand>, CreateItemCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateItemCommand>, UpdateItemCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteItemCommand>, DeleteItemCommandHandler>();

        // Menu
        services.AddScoped<IRequestHandler<CreateMenuCommand>, CreateMenuCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateMenuCommand>, UpdateMenuCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteMenuCommand>, DeleteMenuCommandHandler>();

        // Category
        services.AddScoped<IRequestHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteCategoryCommand>, DeleteCategoryCommandHandler>();

        // Currency
        services.AddScoped<IRequestHandler<CreateCurrencyCommand>, CreateCurrencyCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCurrencyCommand>, UpdateCurrencyCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteCurrencyCommand>, DeleteCurrencyCommandHandler>();

        // Order
        services.AddScoped<IRequestHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateOrderCommand>, UpdateOrderCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteOrderCommand>, DeleteOrderCommandHandler>();

        // Store
        services.AddScoped<IRequestHandler<CreateStoreCommand>, CreateStoreCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateStoreCommand>, UpdateStoreCommandHandler>();
        services.AddScoped<IRequestHandler<DeleteStoreCommand>, DeleteStoreCommandHandler>();

        return services;
    }

    public static IServiceCollection AddNotificationHandlers(this IServiceCollection services)
    {
        // Fanout
        services.AddScoped<IFanoutEventHandler, FanoutEventHandler>();

        // User
        services.AddScoped<INotificationHandler<UserCreatedEvent>, UserEventHandler>();
        services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
        services.AddScoped<INotificationHandler<UserDeletedEvent>, UserEventHandler>();
        services.AddScoped<INotificationHandler<PasswordChangedEvent>, UserEventHandler>();

        // Item
        services.AddScoped<INotificationHandler<ItemCreatedEvent>, ItemEventHandler>();
        services.AddScoped<INotificationHandler<ItemUpdatedEvent>, ItemEventHandler>();
        services.AddScoped<INotificationHandler<ItemDeletedEvent>, ItemEventHandler>();

        // Menu
        services.AddScoped<INotificationHandler<MenuCreatedEvent>, MenuEventHandler>();
        services.AddScoped<INotificationHandler<MenuUpdatedEvent>, MenuEventHandler>();
        services.AddScoped<INotificationHandler<MenuDeletedEvent>, MenuEventHandler>();

        // Category
        services.AddScoped<INotificationHandler<CategoryCreatedEvent>, CategoryEventHandler>();
        services.AddScoped<INotificationHandler<CategoryUpdatedEvent>, CategoryEventHandler>();
        services.AddScoped<INotificationHandler<CategoryDeletedEvent>, CategoryEventHandler>();

        // Currency
        services.AddScoped<INotificationHandler<CurrencyCreatedEvent>, CurrencyEventHandler>();
        services.AddScoped<INotificationHandler<CurrencyUpdatedEvent>, CurrencyEventHandler>();
        services.AddScoped<INotificationHandler<CurrencyDeletedEvent>, CurrencyEventHandler>();

        // Order
        services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderEventHandler>();
        services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
        services.AddScoped<INotificationHandler<OrderDeletedEvent>, OrderEventHandler>();

        // Store
        services.AddScoped<INotificationHandler<StoreCreatedEvent>, StoreEventHandler>();
        services.AddScoped<INotificationHandler<StoreUpdatedEvent>, StoreEventHandler>();
        services.AddScoped<INotificationHandler<StoreDeletedEvent>, StoreEventHandler>();

        return services;
    }

    public static IServiceCollection AddApiUser(this IServiceCollection services)
    {
        // User
        services.AddScoped<IUser, ApiUser>();

        return services;
    }
}