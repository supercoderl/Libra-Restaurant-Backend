using LibraRestaurant.Domain.Entities;
using LibraRestaurant.Domain.Interfaces.Repositories;
using LibraRestaurant.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Infrastructure.Repositories
{
    public sealed class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Reservation?> GetByReservationIdAsync(int reservationId)
        {
            return await DbSet.SingleOrDefaultAsync(item => item.ReservationId == reservationId);
        }

        public async Task<Reservation?> GetByReservationTableNumberAndStoreIdAsync(int tableNumber, Guid storeId)
        {
            return await DbSet.SingleOrDefaultAsync(item => item.TableNumber == tableNumber && item.StoreId == storeId);
        }
    }
}
