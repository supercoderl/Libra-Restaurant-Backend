using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Menus.GetAll;
using LibraRestaurant.Application.Queries.Menus.GetUserById;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Commands.Menus.CreateMenu;
using LibraRestaurant.Domain.Commands.Menus.DeleteMenu;
using LibraRestaurant.Domain.Commands.Menus.UpdateMenu;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.Wards;
using LibraRestaurant.Application.Queries.Wards.GetWardById;
using LibraRestaurant.Application.Queries.Wards.GetAll;

namespace LibraRestaurant.Application.Services
{
    public sealed class WardService : IWardService
    {
        private readonly IMediatorHandler _bus;

        public WardService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<WardViewModel?> GetWardByIdAsync(int wardId)
        {
            return await _bus.QueryAsync(new GetWardByIdQuery(wardId));
        }

        public async Task<PagedResult<WardViewModel>> GetAllWardsAsync(
            PageQuery query,
            bool includeDeleted,
            string searchTerm = "",
            SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllWardsQuery(query, includeDeleted, searchTerm, sortQuery));
        }
    }
}
