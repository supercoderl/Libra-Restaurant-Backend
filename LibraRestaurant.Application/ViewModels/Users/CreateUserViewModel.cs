using System;

namespace LibraRestaurant.Application.ViewModels.Users;

public sealed record CreateUserViewModel(
    string Email,
    string FirstName,
    string LastName,
    string Password);