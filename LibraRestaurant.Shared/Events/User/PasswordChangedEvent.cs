using System;

namespace LibraRestaurant.Shared.Events.User;

public sealed class PasswordChangedEvent : DomainEvent
{
    public PasswordChangedEvent(Guid userId) : base(userId)
    {
    }
}