using LibraRestaurant.Domain.Commands.MenuItems.CreateItem;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.PaymentMethods.CreatePaymentMethod
{
    public sealed class CreatePaymentMethodCommand : CommandBase
    {
        private static readonly CreatePaymentMethodCommandValidation s_validation = new();

        public int PaymentMethodId { get; }
        public string Name { get; }
        public string? Description { get; }
        public bool IsActive { get; }

        public CreatePaymentMethodCommand(
            int paymentMethodId,
            string name,
            string? description,
            bool isActive
        ) : base(paymentMethodId)
        {
            PaymentMethodId = paymentMethodId;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public override bool IsValid()
        {
            ValidationResult = s_validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
