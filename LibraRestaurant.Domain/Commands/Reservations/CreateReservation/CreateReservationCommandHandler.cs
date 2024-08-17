
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Shared.Events.Reservation;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System;
using LibraRestaurant.Shared.Reservations;

namespace LibraRestaurant.Domain.Commands.Reservations.CreateReservation
{
    public sealed class CreateReservationCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public CreateReservationCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IReservationRepository reservationRepository) : base(bus, unitOfWork, notifications)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var reservation = new Entities.Reservation(
                request.ReservationId,
                request.TableNumber,
                request.Capacity,
                request.Status,
                request.StoreId,
                request.Description,
                request.ReservationTime,
                request.CustomerName,
                request.CustomerPhone,
                request.Code);

            _reservationRepository.Add(reservation);

            if (await CommitAsync())
            {
                if(request.ReservationId == 0)
                {
                    string qrData = string.Concat(
                        "{",
                            "\"reservationId\":\"", reservation.ReservationId, "\",",
                            "\"tableNumber\":\"", reservation.TableNumber, "\",",
                            "\"capacity\":\"", reservation.Capacity, "\",",
                            "\"status\":\"", reservation.Status, "\",",
                            "\"storeId\":\"", reservation.StoreId, "\",",
                            "\"description\":\"", reservation.Description, "\",",
                            "\"reservationTime\":\"", reservation.ReservationTime, "\",",
                            "\"customerName\":\"", reservation.CustomerName, "\",",
                            "\"customerPhone\":\"", reservation.CustomerPhone, "\"",
                        "}"
                    );
                    reservation.SetCode(await GenerateQRCode(qrData));

                    await HandleUpdate(reservation);
                }
                await Bus.RaiseEventAsync(new ReservationCreatedEvent(reservation.ReservationId));
            }
        }

        public async Task HandleUpdate(Domain.Entities.Reservation request)
        {
            _reservationRepository.Update(request);
            await CommitAsync();
        }

        //Generate QR Code
        private async Task<string> GenerateQRCode(string qrData)
        {
            await Task.CompletedTask;
            QRCodeGenerator generator = new QRCodeGenerator();
            QRCodeData data = generator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Bitmap bitmap = code.GetGraphic(60);
            byte[] bitmapArray = BitmapToByteArray(bitmap);
            string qrURL = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(bitmapArray));
            return qrURL;
        }

        //Convert bit map to byte array
        private byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
