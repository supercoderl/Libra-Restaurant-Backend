using System;

namespace LibraRestaurant.Application.ViewModels.Categories;

public sealed record CreateCategoryViewModel(
    string Name,
    string Description);