using LibraRestaurant.Domain.Commands.Menus.UpdateMenu;
using LibraRestaurant.Domain.Errors;
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

namespace LibraRestaurant.Domain.Commands.Orders.UpdateOrder
{
    public sealed class UpdateOrderCommandHandler : CommandHandlerBase,
        IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IOrderRepository orderRepository) : base(bus, unitOfWork, notifications)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var order = await _orderRepository.GetByIdAsync(request.OrderId);

            if (order is null)
            {
                await NotifyAsync(
                    new DomainNotification(
                        request.MessageType,
                        $"There is no order with Id {request.OrderId}",
                        ErrorCodes.ObjectNotFound));
                return;
            }

            if(request.OrderNo is not null)
            {
                order.SetOrderNo(request.OrderNo);
            }
            order.SetStoreId(request.StoreId);
            order.SetPaymentMethodId(request.PaymentMethodId);
            order.SetPaymentTimeId(request.PaymentTimeId);
            order.SetServantId(request.ServantId);
            order.SetCashierId(request.CashierId);
            order.SetCustomerNotes(request.CustomerNotes);
            order.SetReservationId(request.ReservationId);
            order.SetPriceCalculated(request.PriceCalculated);
            order.SetPriceAdjustment(request.PriceAdjustment);
            order.SetPriceAdjustmentReason(request.PriceAdjustmentReason);
            order.SetSubtotal(request.Subtotal);
            order.SetTax(request.Tax);
            order.SetTotal(request.Total);
            order.SetLatestStatus(request.LatestStatus);
            order.SetLatestStatusUpdate(request.LatestStatusUpdate);
            order.SetIsPaid(request.IsPaid);
            order.SetIsPreparationDelayed(request.IsPreparationDelayed);
            order.SetDelayTime(request.DelayedTime);
            order.SetIsCanceled(request.IsCanceled);
            order.SetCancelTime(request.CanceledTime);
            order.SetCanceledReason(request.CanceledReason);
            order.SetIsReady(request.IsReady);
            order.SetReadyTime(request.ReadyTime);
            order.SetIsCompleted(request.IsCompleted);
            order.SetCompletedTime(request.CompletedTime);

            _orderRepository.Update(order);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new OrderUpdatedEvent(order.OrderId));
            }
        }
    }
}
