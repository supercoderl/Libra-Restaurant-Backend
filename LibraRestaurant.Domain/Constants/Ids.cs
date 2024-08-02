using System;

namespace LibraRestaurant.Domain.Constants;

public static class Ids
{
    public static class Seed
    {
        public static readonly Guid UserId = Guid.NewGuid();
        public static readonly int NumberId = 1;
    }
}