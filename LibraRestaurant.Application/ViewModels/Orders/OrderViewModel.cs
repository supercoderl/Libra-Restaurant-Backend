using System;
using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Enums;

namespace LibraRestaurant.Application.ViewModels.Orders;

public sealed class OrderViewModel
{
    public Guid OrderId { get; set; }
    public string OrderNo { get; set; } = string.Empty;
    public Guid StoreId { get; set; }
    public int PaymentMethodId { get; set; } 
    public int PaymentTimeId { get; set; }
    public Guid ServantId { get; set; }
    public Guid CashierId { get; set; }
    public string? CustomerNotes { get; set; }
    public int ReservationId { get; set; }
    public double PriceCalculated { get; set; }
    public double? PriceAdjustment { get; set; }
    public string? PriceAdjustmentReason { get; set; }
    public double Subtotal { get; set; }
    public double Tax { get; set; }
    public double Total { get; set; }
    public string LatestStatus { get; set; } = string.Empty;
    public string LatestStatusUpdate { get; set; } = string.Empty;
    public bool IsPaid { get; set; }
    public bool IsPreparationDelayed { get; set; }
    public DateTime? DelayedTime { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime? CanceledTime { get; set; }
    public string? CanceledReason { get; set; }
    public bool IsReady { get; set; }
    public DateTime? ReadyTime { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedTime { get; set; }

    public static OrderViewModel FromOrder(OrderHeader order)
    {
        return new OrderViewModel
        {
            OrderId = order.OrderId,
            OrderNo = order.OrderNo,
            StoreId = order.StoreId,
            PaymentMethodId = order.PaymentMethodId,
            PaymentTimeId = order.PaymentTimeId,
            ServantId = order.ServantId,
            CashierId = order.CashierId,
            CustomerNotes = order.CustomerNotes,
            ReservationId = order.ReservationId,
            PriceCalculated = order.PriceCalculated,
            PriceAdjustment = order.PriceAdjustment,
            PriceAdjustmentReason = order.PriceAdjustmentReason,
            Subtotal = order.Subtotal,
            Tax = order.Tax,
            Total = order.Total,
            LatestStatus = order.LatestStatus,
            LatestStatusUpdate = order.LatestStatusUpdate,
            IsPaid = order.IsPaid,
            IsPreparationDelayed = order.IsPreparationDelayed,
            DelayedTime = order.DelayedTime,
            IsCanceled = order.IsCanceled,
            CanceledTime = order.CanceledTime,
            CanceledReason = order.CanceledReason,
            IsReady = order.IsReady,
            ReadyTime = order.ReadyTime,
            IsCompleted = order.IsCompleted,
            CompletedTime = order.CompletedTime,
        };
    }
}