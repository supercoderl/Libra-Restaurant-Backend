using LibraRestaurant.Domain.Commands.MenuItems.CreateItem;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.OrderLines.CreateOrderLine
{
    public sealed class CreateOrderLineCommand : CommandBase
    {
        private static readonly CreateOrderLineCommandValidation s_validation = new();

        public int OrderLineId { get; }
        public Guid OrderId { get; }
        public int ItemId { get; }
        public int Quantity { get; }
        public bool IsCanceled { get; }
        public DateTime? CanceledTime { get; }
        public string? CanceledReason { get; }
        public string? CustomerReview { get; }
        public CustomerLikeStatus CustomerLike { get; }

        public CreateOrderLineCommand(
            int orderLineId,
            Guid orderId,
            int itemId,
            int quantity,
            bool isCanceled,
            DateTime? canceledTime,
            string? canceledReason,
            string? customerReview,
            CustomerLikeStatus customerLike
        ) : base(orderLineId)
        {
            OrderLineId = orderLineId;
            OrderId = orderId;
            ItemId = itemId;
            Quantity = quantity;
            IsCanceled = isCanceled;
            CanceledTime = canceledTime;
            CustomerLike = customerLike;
            CustomerReview = customerReview;
            CustomerLike = customerLike;
        }

        public override bool IsValid()
        {
            ValidationResult = s_validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
