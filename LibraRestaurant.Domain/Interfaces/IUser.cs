using System;
using LibraRestaurant.Domain.Enums;

namespace LibraRestaurant.Domain.Interfaces;

public interface IUser
{
    string Name { get; }
    Guid GetUserId();
    UserRole GetUserRole();
    string GetUserEmail();
}