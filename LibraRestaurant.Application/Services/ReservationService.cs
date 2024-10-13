using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.Reservations;
using LibraRestaurant.Application.Queries.Reservations.GetReservationById;
using LibraRestaurant.Application.Queries.Reservations.GetAll;
using LibraRestaurant.Domain.Commands.Reservations.CreateReservation;
using LibraRestaurant.Domain.Enums;
using LibraRestaurant.Domain.Commands.Reservations.UpdateReservation;
using LibraRestaurant.Domain.Commands.Reservations.DeleteReservation;
using System.IO;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using LibraRestaurant.Application.Queries.Reservations.GetReservationByTableNumberAndStoreId;
using System.Text.Json;
using LibraRestaurant.Application.Queries.Reservations.GetAllTablesRealTime;
using System.Collections.Generic;

namespace LibraRestaurant.Application.Services
{
    public sealed class ReservationService : IReservationService
    {
        private readonly IMediatorHandler _bus;

        public ReservationService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<ReservationViewModel?> GetReservationByIdAsync(int reservationId)
        {
            return await _bus.QueryAsync(new GetReservationByIdQuery(reservationId));
        }

        public async Task<PagedResult<ReservationViewModel>> GetAllReservationsAsync(
            PageQuery query,
            bool includeDeleted,
            string searchTerm = "",
            SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllReservationsQuery(query, includeDeleted, searchTerm, sortQuery));
        }

        public async Task<List<TableRealTimeViewModel>> GetAllTablesRealTimeAsync(bool includeDeleted)
        {
            return await _bus.QueryAsync(new GetAllTablesRealTimeQuery(includeDeleted));
        }

        public async Task<ReservationViewModel?> GetReservationByTableNumberAndStoreIdAsync(int tableNumber, Guid storeId)
        {
            return await _bus.QueryAsync(new GetReservationByTableNumberAndStoreIdQuery(tableNumber, storeId));
        }

        public async Task<int?> GetReservationStatus(int reservationId)
        {
            var reservation = await _bus.QueryAsync(new GetReservationByIdQuery(reservationId));
            if (reservation is not null)
            {
                return Convert.ToInt32(reservation.Status);
            }
            return null;
        }

        public async Task<int> CreateReservationAsync(CreateReservationViewModel reservation)
        {

            await _bus.SendCommandAsync(new CreateReservationCommand(
                0,
                reservation.TableNumber,
                reservation.Capacity,
                ReservationStatus.Available,
                reservation.StoreId,
                reservation.Description,
                reservation.ReservationTime,
                reservation.CustomerName,
                reservation.CustomerPhone,
                null));

            return 0;
        }

        public async Task UpdateReservationAsync(UpdateReservationViewModel reservation)
        {
            await _bus.SendCommandAsync(new UpdateReservationCommand(
                reservation.ReservationId,
                reservation.TableNumber,
                reservation.Capacity,
                reservation.Status,
                reservation.StoreId,
                reservation.Description,
                reservation.ReservationTime,
                reservation.CustomerName,
                reservation.CustomerPhone,
                reservation.QRCode));
        }

        public async Task DeleteReservationAsync(int reservationId)
        {
            await _bus.SendCommandAsync(new DeleteReservationCommand(reservationId));
        }
    }
}
