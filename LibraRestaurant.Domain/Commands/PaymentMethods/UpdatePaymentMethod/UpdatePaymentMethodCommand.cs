using LibraRestaurant.Domain.Commands.Menu.UpdateMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.PaymentMethods.UpdatePaymentMethod
{
    public sealed class UpdatePaymentMethodCommand : CommandBase
    {
        private static readonly UpdatePaymentMethodCommandValidation s_validation = new();

        public int PaymentMethodId { get; }
        public string Name { get; }
        public string? Description { get; }
        public bool IsActive { get; }

        public UpdatePaymentMethodCommand(
            int paymentMethodId,
            string name,
            string? description,
            bool isActive) : base(paymentMethodId)
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
