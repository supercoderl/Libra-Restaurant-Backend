using System;

namespace LibraRestaurant.Shared.Categories;

public sealed record CategoryViewModel(
    int CategoryId,
    string Name,
    string? Description,
    bool IsActive,
    bool IsDeleted);