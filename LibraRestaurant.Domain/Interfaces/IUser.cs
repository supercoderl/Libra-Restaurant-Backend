using System;

namespace LibraRestaurant.Domain.Interfaces;

public interface IUser
{
    string Name { get; }
    Guid GetUserId();
    string GetUserEmail();
}