﻿using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Menus.GetAll;
using LibraRestaurant.Application.Queries.Menus.GetUserById;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Commands.Menus.DeleteMenu;
using LibraRestaurant.Domain.Commands.Menus.UpdateMenu;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.Orders;
using LibraRestaurant.Domain.Commands.Orders.CreateOrder;
using LibraRestaurant.Domain.Commands.Orders.UpdateOrder;
using LibraRestaurant.Domain.Commands.Orders.DeleteOrder;
using LibraRestaurant.Application.Queries.Orders.GetOrderById;
using LibraRestaurant.Application.Queries.Orders.GetAll;

namespace LibraRestaurant.Application.Services
{
    public sealed class OrderService : IOrderService
    {
        private readonly IMediatorHandler _bus;

        public OrderService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<OrderViewModel?> GetOrderByIdAsync(Guid orderId)
        {
            return await _bus.QueryAsync(new GetOrderByIdQuery(orderId));
        }

        public async Task<PagedResult<OrderViewModel>> GetAllOrdersAsync(
            PageQuery query,
            bool includeDeleted,
            string searchTerm = "",
            SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllOrdersQuery(query, includeDeleted, searchTerm, sortQuery));
        }

        public async Task<int> CreateOrderAsync(CreateOrderViewModel order)
        {
            await _bus.SendCommandAsync(new CreateOrderCommand(
                Guid.NewGuid(),
                "00000001",
                order.StoreId,
                1,
                1,
                Guid.NewGuid(),
                Guid.NewGuid(),
                null,
                1,
                1000000,
                null,
                null,
                1000000,
                10,
                1000010,
                string.Empty,
                string.Empty,
                false,
                false,
                null,
                false,
                null,
                null,
                true,
                DateTime.Now,
                false,
                null));

            return 0;
        }

        public async Task UpdateOrderAsync(UpdateOrderViewModel order)
        {
            await _bus.SendCommandAsync(new UpdateOrderCommand(
                order.OrderId,
                order.OrderNo,
                order.StoreId,
                order.PaymentMethodId,
                order.PaymentTimeId,
                order.ServantId,
                order.CashierId,
                order.CustomerNotes,
                order.ReservationId,
                order.PriceCalculated,
                order.PriceAdjustment,
                order.PriceAdjustmentReason,
                order.Subtotal,
                order.Tax,
                order.Total,
                order.LatestStatus,
                order.LatestStatusUpdate,
                order.IsPaid,
                order.IsPreparationDelayed,
                order.DelayedTime,
                order.IsCanceled,
                order.CaceledTime,
                order.CanceledReason,
                order.IsReady,
                order.ReadyTime,
                order.IsCompleted,
                order.CompletedTime));
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            await _bus.SendCommandAsync(new DeleteOrderCommand(orderId));
        }
    }
}