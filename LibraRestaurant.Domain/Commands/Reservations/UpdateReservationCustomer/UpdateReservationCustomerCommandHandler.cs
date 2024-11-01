
using LibraRestaurant.Domain.Errors;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Domain.Interfaces;
using LibraRestaurant.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LibraRestaurant.Shared.Events.MenuItem;
using LibraRestaurant.Shared.Events.Menu;
using LibraRestaurant.Domain.Commands.Reservations.UpdateReservation;
using LibraRestaurant.Shared.Events.Reservation;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace LibraRestaurant.Domain.Commands.Reservations.UpdateReservationCustomer
{
    public sealed class UpdateReservationCustomerCommandHandler : CommandHandlerBase,
        IRequestHandler<UpdateReservationCustomerCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCustomerCommandHandler(
            IMediatorHandler bus,
            IUnitOfWork unitOfWork,
            INotificationHandler<DomainNotification> notifications,
            IReservationRepository reservationRepository) : base(bus, unitOfWork, notifications)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(UpdateReservationCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!await TestValidityAsync(request))
            {
                return;
            }

            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationId);

            if (reservation is null)
            {
                await NotifyAsync(
                    new DomainNotification(
                        request.MessageType,
                        $"There is no reservation with Id {request.ReservationId}",
                        ErrorCodes.ObjectNotFound));
                return;
            }

            reservation.SetStatus(request.Status);
            reservation.SetCustomerName(request.CustomerName);
            reservation.SetCustomerPhone(request.CustomerPhone);

            _reservationRepository.Update(reservation);

            if (await CommitAsync())
            {
                await Bus.RaiseEventAsync(new ReservationUpdatedEvent(reservation.ReservationId));
            }
        }
    }
}
