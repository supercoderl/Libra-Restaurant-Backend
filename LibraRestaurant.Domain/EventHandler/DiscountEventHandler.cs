using LibraRestaurant.Shared.Events.Discount;
using LibraRestaurant.Shared.Events.Role;
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
    public sealed class DiscountEventHandler :
                    INotificationHandler<DiscountDeletedEvent>,
                    INotificationHandler<DiscountCreatedEvent>,
                    INotificationHandler<DiscountUpdatedEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public DiscountEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(DiscountCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(DiscountDeletedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(DiscountUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }
    }
}
