using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class QRCode : Entity
    {
        public int QRCodeId { get; private set; }
        public string Code { get; private set; }
        public int ReservationId { get; private set; }

        public QRCode(
            int qrCodeId,
            string code,
            int reservationId
        ) : base (qrCodeId)
        {
            QRCodeId = qrCodeId;
            Code = code;
            ReservationId = reservationId;
        }

        public void SetCode( string code )
        {
            Code = code;
        }

        public void SetReservationId( int reservationId )
        {
            ReservationId = reservationId;
        }
    }
}
