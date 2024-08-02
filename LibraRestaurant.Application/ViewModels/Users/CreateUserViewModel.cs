using System;

namespace LibraRestaurant.Application.ViewModels.Users;

public sealed record CreateUserViewModel(
    string Email,
    string FirstName,
    string Mobile,
    string LastName,
    string Password,
    DateTime RegisteredDate);