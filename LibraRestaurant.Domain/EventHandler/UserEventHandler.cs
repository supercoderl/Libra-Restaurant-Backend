using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Shared.Events.User;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraRestaurant.Domain.EventHandler;

public sealed class UserEventHandler :
    INotificationHandler<UserDeletedEvent>,
    INotificationHandler<UserCreatedEvent>,
    INotificationHandler<UserUpdatedEvent>,
    INotificationHandler<PasswordChangedEvent>
{
    private readonly IDistributedCache _distributedCache;

    public UserEventHandler(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public Task Handle(PasswordChangedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
/*        await _distributedCache.RemoveAsync(
            CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
            cancellationToken);*/
    }

    public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
    {
/*        await _distributedCache.RemoveAsync(
            CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
            cancellationToken);*/
    }

    public async Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
/*        await _distributedCache.RemoveAsync(
            CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
            cancellationToken);*/
    }
}