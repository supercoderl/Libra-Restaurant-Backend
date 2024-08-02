using LibraRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class Reservation : Entity
    {
        public int ReservationId { get; private set; }
        public int TableNumber { get; private set; }
        public int Capacity { get; private set; }
        public ReservationStatus Status { get; private set; }
        public Guid StoreId { get; private set; }
        public string? Description { get; private set; }
        public DateTime? ReservationTime { get; private set; }
        public string? CustomerName { get; private set; }
        public string? CustomerPhone { get; private set; }

        public Reservation(
            int reservationId,
            int tableNumber,
            int capacity,
            ReservationStatus status,
            Guid storeId,
            string? description,
            DateTime? reservationTime,
            string? customerName,
            string? customerPhone
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
        }

        public void SetTableNumber( int tableNumber )
        {
            TableNumber = tableNumber;
        }

        public void SetCapacity( int capacity ) 
        { 
            Capacity = capacity; 
        } 
        
        public void SetStatus( ReservationStatus status ) 
        {
            Status = status;
        }

        public void SetStoreId( Guid storeId )
        {
            StoreId = storeId;
        }

        public void SetDescription( string? description )
        {
            Description = description;
        }

        public void SetReservationTime( DateTime? reservationTime )
        {
            ReservationTime = reservationTime;
        }

        public void SetCustomerName( string? customerName )
        {
            CustomerName = customerName;
        }

        public void SetCustomerPhone( string? customerPhone )
        {
            CustomerPhone = customerPhone;
        }
    }
}
