using System;

namespace LibraRestaurant.Shared.Users;

public sealed record UserViewModel(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    bool IsDeleted);