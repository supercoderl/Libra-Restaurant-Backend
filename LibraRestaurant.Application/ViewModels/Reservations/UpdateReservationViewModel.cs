using System;
using LibraRestaurant.Domain.Enums;

namespace LibraRestaurant.Application.ViewModels.Reservations;

public sealed record UpdateReservationViewModel(
    int ReservationId,
    int TableNumber,
    int Capacity,
    Guid StoreId,
    ReservationStatus Status,
    string? Description,
    DateTime? ReservationTime,
    string? CustomerName,
    string? CustomerPhone,
    string? Code);