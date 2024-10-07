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
using LibraRestaurant.Domain.Commands.OrderLines.CreateOrderLine;

namespace LibraRestaurant.Domain.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderCommandHandler : CommandHandlerBase,
            IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;

        public CreateOrderCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IOrderRepository orderRepository,
            IOrderLineRepository orderLineRepository) : base(bus, unitOfWork, notifications)
        {
            _orderRepository = orderRepository;
            _orderLineRepository = orderLineRepository;
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

            await AddItems(request.OrderLines, request.OrderId);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new OrderCreatedEvent(order.OrderId));
            }
        }

        private async Task AddItems (List<CreateOrderLineCommand> OrderLines, Guid OrderId)
        {
            foreach (var item in OrderLines)
            {
                // Kiểm tra xem OrderLine đã tồn tại trong DB chưa
                var existingOrderLine = await _orderLineRepository.GetByOrderAndItemAsync(OrderId, item.ItemId);

                if (existingOrderLine != null)
                {
                    // Nếu tồn tại, kiểm tra quantity
                    if (existingOrderLine.Quantity < item.Quantity)
                    {
                        // Nếu quantity trong DB nhỏ hơn quantity truyền vào, cập nhật giá trị
                        existingOrderLine.SetQuantity(item.Quantity);
                        _orderLineRepository.Update(existingOrderLine); // Cập nhật lại
                    }
                }
                else
                {
                    // Nếu không có trong DB, thêm mới
                    var orderItem = new Entities.OrderLine(
                        item.OrderLineId,
                        OrderId,
                        item.ItemId,
                        item.Quantity,
                        item.IsCanceled,
                        item.CanceledTime,
                        item.CanceledReason,
                        item.CustomerReview,
                        item.CustomerLike
                    );

                    _orderLineRepository.Add(orderItem); // Thêm mới
                }
            }
        }
    }
}
