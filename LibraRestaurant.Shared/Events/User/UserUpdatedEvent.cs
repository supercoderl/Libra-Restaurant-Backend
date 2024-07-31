using System;

namespace LibraRestaurant.Shared.Events.User;

public sealed class UserUpdatedEvent : DomainEvent
{

    public UserUpdatedEvent(Guid userId) : base(userId)
    {

    }
}