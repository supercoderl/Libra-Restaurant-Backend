using LibraRestaurant.Shared.Events.Menu;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.EventHandler
{
    public sealed class MenuEventHandler :
            INotificationHandler<MenuDeletedEvent>,
            INotificationHandler<MenuCreatedEvent>,
            INotificationHandler<MenuUpdatedEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public MenuEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(MenuDeletedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(MenuUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }
    }
}
