﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class OrderHeader : Entity
    {
        public Guid OrderId { get; private set; }   
        public string OrderNo { get; private set; }
        public Guid StoreId { get; private set; }
        public int PaymentMethodId { get; private set; }
        public int PaymentTimeId { get; private set; }
        public Guid ServantId { get; private set; }
        public Guid CashierId { get; private set; }
        public string? CustomerNotes { get; private set; }
        public int ReservationId { get; private set; }
        public double PriceCalculated { get; private set; }
        public double? PriceAdjustment { get; private set; }
        public string? PriceAdjustmentReason { get; private set; }
        public double Subtotal { get; private set; }
        public double Tax { get; private set; }
        public double Total { get; private set; }
        public string LatestStatus { get; private set; }
        public string LatestStatusUpdate {  get; private set; }
        public bool IsPaid { get; private set; }
        public bool IsPreparationDelayed { get; private set; }
        public DateTime? DelayedTime { get; private set; }
        public bool IsCanceled { get; private set; }
        public DateTime? CanceledTime { get; private set; }
        public string? CanceledReason { get; private set; }
        public bool IsReady { get; private set; }
        public DateTime? ReadyTime { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletedTime { get; private set; }

        public OrderHeader(
            Guid orderId,
            string orderNo,
            Guid storeId,
            int paymentMethodId,
            int paymentTimeId,
            Guid servantId,
            Guid cashierId,
            string? customerNotes,
            int reservationId,
            double priceCalculated,
            double? priceAdjustment,
            string? priceAdjustmentReason,
            double subtotal,
            double tax,
            double total,
            string latestStatus,
            string latestStatusUpdate,
            bool isPaid,
            bool isPreparationDelay,
            DateTime? delayTime,
            bool isCanceled,
            DateTime? canceledTime,
            string? canceledReason,
            bool isReady,
            DateTime? readyTime,
            bool isCompleted,
            DateTime? completedTime
        ) : base (orderId)
        {
            OrderId = orderId;
            OrderNo = orderNo;
            StoreId = storeId;
            PaymentMethodId = paymentMethodId;
            PaymentTimeId = paymentTimeId;
            ServantId = servantId;
            CashierId = cashierId;
            CustomerNotes = customerNotes;
            ReservationId = reservationId;
            PriceCalculated = priceCalculated;
            PriceAdjustment = priceAdjustment;
            PriceAdjustmentReason = priceAdjustmentReason;
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            LatestStatus = latestStatus;
            LatestStatusUpdate = latestStatusUpdate;
            IsPaid = isPaid;
            IsPreparationDelayed = isPreparationDelay;
            DelayedTime = delayTime;
            IsCanceled = isCanceled;
            CanceledTime = canceledTime;
            CanceledReason = canceledReason;
            IsReady = isReady;
            ReadyTime = readyTime;
            IsCompleted = isCompleted;
            CompletedTime = completedTime;
        }

        public void SetOrderNo( string orderNo )
        {
            OrderNo = orderNo;
        }

        public void SetStoreId( Guid storeId )
        {
            StoreId = storeId;
        }

        public void SetPaymentMethodId( int paymentMethodId )
        {
            PaymentMethodId = paymentMethodId;
        }

        public void SetPaymentTimeId( int paymentTimeId )
        {
            PaymentTimeId = paymentTimeId;
        }

        public void SetServantId( Guid serantId )
        {
            ServantId = serantId;
        }

        public void SetCashierId( Guid cashierId )
        {
            CashierId = cashierId;
        }

        public void SetCustomerNotes( string? customerNotes )
        {
            CustomerNotes = customerNotes;
        }

        public void SetReservationId( int reservationId )
        {
            ReservationId = reservationId;
        }

        public void SetPriceCalculated( double priceCalculated )
        {
            PriceCalculated = priceCalculated;
        }

        public void SetPriceAdjustment( double? priceAdjustment )
        {
            PriceAdjustment = priceAdjustment;
        }

        public void SetPriceAdjustmentReason( string? priceAdjustmentReason )
        {
            PriceAdjustmentReason = priceAdjustmentReason;
        }

        public void SetSubtotal( double subtotal )
        {
            Subtotal = subtotal;
        }

        public void SetTax( double tax )
        {
            Tax = tax;
        }

        public void SetTotal( double total ) 
        { 
            Total = total; 
        }

        public void SetLatestStatus( string latestStatus )
        {
            LatestStatus = latestStatus;
        }

        public void SetLatestStatusUpdate( string latestStatusUpdate )
        {
            LatestStatusUpdate = latestStatusUpdate;
        }

        public void SetIsPaid( bool isPaid )
        {
            IsPaid = isPaid;
        }

        public void SetIsPreparationDelay( bool isPreparationDelay )
        {
            IsPreparationDelayed = isPreparationDelay;
        }

        public void SetDelayTime( DateTime? delayTime )
        {
            DelayedTime = delayTime;
        }

        public void SetIsCanceled( bool isCanceled )
        {
            IsCanceled = isCanceled;
        }

        public void SetCancelTime( DateTime? cancelTime )
        {
            CanceledTime = cancelTime;
        }

        public void SetCanceledReason( string? cancelReason )
        {
            CanceledReason = cancelReason;
        }

        public void SetIsReady( bool isReady )
        {
            IsReady = isReady;
        }

        public void SetReadyTime( DateTime? readyTime )
        {
            ReadyTime = readyTime;
        }

        public void SetIsCompleted( bool isCompleted )
        {
            IsCompleted = isCompleted;
        }

        public void SetCompletedTime( DateTime? completedTime )
        {
            CompletedTime = completedTime;
        }
    }
}