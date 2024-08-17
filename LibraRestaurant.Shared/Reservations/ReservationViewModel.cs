using System;

namespace LibraRestaurant.Shared.Reservations;

public sealed record ReservationViewModel(
    int ReservationId,
    int TableNumber,
    int Capacity,
    Guid StoreId,
    string? Description,
    DateTime? ReservationTime,
    string? CustomerName,
    string? CustomerPhone,
    string? Code,
    bool IsDeleted);