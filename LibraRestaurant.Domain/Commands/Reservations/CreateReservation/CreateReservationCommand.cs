using LibraRestaurant.Domain.Commands.MenuItems.CreateItem;
using LibraRestaurant.Domain.Commands.Users.CreateUser;
using LibraRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.Reservations.CreateReservation
{
    public sealed class CreateReservationCommand : CommandBase
    {
        private static readonly CreateReservationCommandValidation s_validation = new();

        public int ReservationId { get; }
        public int TableNumber { get; }
        public int Capacity { get; }
        public ReservationStatus Status { get; }
        public Guid StoreId { get; }
        public string? Description { get; }
        public DateTime? ReservationTime { get; }
        public string? CustomerName { get; }
        public string? CustomerPhone { get; }
        public string? Code { get; }

        public CreateReservationCommand(
            int reservationId,
            int tableNumber,
            int capacity,
            ReservationStatus status,
            Guid storeId,
            string? description,
            DateTime? reservationTime,
            string? customerName,
            string? customerPhone,
            string? code
        ) : base(reservationId)
        {
            ReservationId = reservationId;
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            StoreId = storeId;
            Description = description;
            ReservationTime = reservationTime;
            CustomerName = customerName;
            CustomerPhone = customerPhone;
            Code = code;
        }

        public override bool IsValid()
        {
            ValidationResult = s_validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
