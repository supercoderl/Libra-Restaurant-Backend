using System;

namespace LibraRestaurant.Shared.Events.User;

public sealed class UserCreatedEvent : DomainEvent
{
    public UserCreatedEvent(Guid userId) : base(userId)
    {
    }
}