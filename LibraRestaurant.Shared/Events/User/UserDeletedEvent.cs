using System;

namespace LibraRestaurant.Shared.Events.User;

public sealed class UserDeletedEvent : DomainEvent
{

    public UserDeletedEvent(Guid userId) : base(userId)
    {

    }
}