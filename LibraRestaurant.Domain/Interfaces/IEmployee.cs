using System;

namespace LibraRestaurant.Domain.Interfaces;

public interface IEmployee
{
    string Name { get; }
    Guid GetEmployeeId();
    string GetEmployeeEmail();
}