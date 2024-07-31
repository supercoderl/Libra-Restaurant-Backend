
using LibraRestaurant.Domain.Commands.Users.ChangePassword;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Commands.Users.DeleteUser;
using LibraRestaurant.Domain.Commands.Users.LoginUser;
using LibraRestaurant.Domain.Commands.Users.UpdateUser;
using LibraRestaurant.Domain.EventHandler;
using LibraRestaurant.Domain.EventHandler.Fanout;
using LibraRestaurant.Domain.Interfaces;
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

        return services;
    }

    public static IServiceCollection AddApiUser(this IServiceCollection services)
    {
        // User
        services.AddScoped<IUser, ApiUser>();

        return services;
    }
}