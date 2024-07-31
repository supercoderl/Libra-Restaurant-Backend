using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraRestaurant.Shared.Users;

namespace LibraRestaurant.gRPC.Interfaces;

public interface IUsersContext
{
    Task<IEnumerable<UserViewModel>> GetUsersByIds(IEnumerable<Guid> ids);
}