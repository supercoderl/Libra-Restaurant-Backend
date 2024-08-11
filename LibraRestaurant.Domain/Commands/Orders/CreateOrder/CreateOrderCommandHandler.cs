using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Notifications;
using LibraRestaurant.Shared.Events.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Shared.Events.OrderHead;

namespace LibraRestaurant.Domain.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderCommandHandler : CommandHandlerBase,
            IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IOrderRepository orderRepository) : base(bus, unitOfWork, notifications)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var order = new Entities.OrderHeader(
                request.OrderId,
                request.OrderNo,
                request.StoreId,
                request.PaymentMethodId,
                request.PaymentTimeId,
                request.ServantId,
                request.CashierId,
                request.CustomerNotes,
                request.ReservationId,
                request.PriceCalculated,
                request.PriceAdjustment,
                request.PriceAdjustmentReason,
                request.Subtotal,
                request.Tax,
                request.Total,
                request.LatestStatus,
                request.LatestStatusUpdate,
                request.IsPaid,
                request.IsPreparationDelayed,
                request.DelayedTime,
                request.IsCanceled,
                request.CanceledTime,
                request.CanceledReason,
                request.IsReady,
                request.ReadyTime,
                request.IsCompleted,
                request.CompletedTime);

            _orderRepository.Add(order);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new OrderCreatedEvent(order.OrderId));
            }
        }
    }
}
