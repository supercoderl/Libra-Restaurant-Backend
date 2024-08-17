 using LibraRestaurant.Shared.Events.Menu;
using LibraRestaurant.Shared.Events.Reservation;
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
    public sealed class ReservationEventHandler :
                INotificationHandler<ReservationDeletedEvent>,
                INotificationHandler<ReservationCreatedEvent>,
                INotificationHandler<ReservationUpdatedEvent>
    {
        private readonly IDistributedCache _distributedCache;

        public ReservationEventHandler(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task Handle(ReservationCreatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(ReservationDeletedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }

        public async Task Handle(ReservationUpdatedEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            /*        await _distributedCache.RemoveAsync(
                        CacheKeyGenerator.GetEntityCacheKey<Tenant>(notification.TenantId),
                        cancellationToken);*/
        }
    }
}
