﻿using LibraRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Interfaces.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<Menu?> GetByStoreAsync(Guid storeId);
    }
}