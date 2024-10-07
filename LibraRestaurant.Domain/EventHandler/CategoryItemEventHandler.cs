using LibraRestaurant.Shared.Events.Category;
using LibraRestaurant.Shared.Events.CategoryItem;
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
    public sealed class CategoryItemEventHandler :
                    INotificationHandler<CategoryItemDeletedEvent>,
                    INotificationHandler<CategoryItemCreatedEvent>,
                    INotificationHandler<CategoryItemUpdatedEvent>,
                    INotificationHandler<CategoryItemUpsertEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public CategoryItemEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(CategoryItemCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(CategoryItemDeletedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(CategoryItemUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(CategoryItemUpsertEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }
    }
}
