using LibraRestaurant.Shared.Events.Menu;
using LibraRestaurant.Shared.Events.PaymentMethod;
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
    public sealed class PaymentMethodEventHandler :
                INotificationHandler<PaymentMethodDeletedEvent>,
                INotificationHandler<PaymentMethodCreatedEvent>,
                INotificationHandler<PaymentMethodUpdatedEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public PaymentMethodEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(PaymentMethodCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(PaymentMethodDeletedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(PaymentMethodUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }
    }
}
