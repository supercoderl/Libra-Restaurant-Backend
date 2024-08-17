using LibraRestaurant.Domain.Enums;
using System;

namespace LibraRestaurant.Application.ViewModels.OrderLines;

public sealed record CreateOrderLineViewModel(
    Guid OrderId,
    int ItemId,
    int Quantity,
    bool IsCanceled,
    DateTime? CanceledTime,
    string? CanceledReason,
    string? CustomerReview,
    CustomerLikeStatus CustomerLike);