using FluentValidation;
using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.Orders.CreateOrder
{
    public sealed class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            AddRuleForOrderNo();
            AddRuleForStore();
            AddRuleForServant();
            AddRuleForCashier();
            AddRuleForReservation();
            AddRuleForPriceCalculated();
            AddRuleForSubtotal();
            AddRuleForTax();
            AddRuleForTotal();
        }

        private void AddRuleForOrderNo()
        {
            RuleFor(cmd => cmd.OrderNo)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Menu.EmptyName)
                .WithMessage("Name may not be empty");
        }

        private void AddRuleForStore()
        {
            RuleFor(cmd => cmd.StoreId)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyStore)
                .WithMessage("Store may not be empty");
        }

        private void AddRuleForServant()
        {
            RuleFor(cmd => cmd.ServantId)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyServant)
                .WithMessage("Servant may not be empty");
        }

        private void AddRuleForCashier()
        {
            RuleFor(cmd => cmd.CashierId)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyCashier)
                .WithMessage("Cashier may not be empty");
        }

        private void AddRuleForReservation()
        {
            RuleFor(cmd => cmd.ReservationId)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyReservation)
                .WithMessage("Reservation may not be empty");
        }

        private void AddRuleForPriceCalculated()
        {
            RuleFor(cmd => cmd.PriceCalculated)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyPriceCalculated)
                .WithMessage("Price calculated may not be empty");
        }

        private void AddRuleForSubtotal()
        {
            RuleFor(cmd => cmd.Subtotal)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptySubtotal)
                .WithMessage("Subtotal may not be empty");
        }

        private void AddRuleForTax()
        {
            RuleFor(cmd => cmd.Tax)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyTax)
                .WithMessage("Tax may not be empty");
        }

        private void AddRuleForTotal()
        {
            RuleFor(cmd => cmd.Total)
                .NotEmpty()
                .WithErrorCode(DomainErrorCodes.Order.EmptyTotal)
                .WithMessage("Total may not be empty");
        }
    }
}
