﻿using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.MenuItems.GetAll;
using LibraRestaurant.Application.Queries.MenuItems.GetById;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Application.ViewModels.MenuItems;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Domain.Commands.MenuItems.CreateItem;
using LibraRestaurant.Domain.Commands.MenuItems.DeleteItem;
using LibraRestaurant.Domain.Commands.MenuItems.UpdateItem;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.Services
{
    public sealed class MenuItemService : IMenuItemService
    {
        private readonly IMediatorHandler _bus;

        public MenuItemService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<int> CreateItemAsync(CreateItemViewModel item)
        {
            await _bus.SendCommandAsync(new CreateItemCommand(
                0,
                item.Title,
                item.Slug,
                item.Summary,
                item.SKU,
                item.Price,
                item.Quantity,
                item.Recipe,
                item.Instruction
            ));

            return 0;
        }

        public async Task DeleteItemAsync(int itemId)
        {
            await _bus.SendCommandAsync(new DeleteItemCommand(itemId));
        }

        public async Task<PagedResult<ItemViewModel>> GetAllItemsAsync(PageQuery query, bool includeDeleted, string searchTerm = "", SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllItemsQuery(query, includeDeleted, searchTerm, sortQuery));
        }

        public async Task<ItemViewModel?> GetItemByIdAsync(int itemId)
        {
            return await _bus.QueryAsync(new GetItemByIdQuery(itemId));
        }

        public async Task UpdateItemAsync(UpdateItemViewModel item)
        {
            await _bus.SendCommandAsync(new UpdateItemCommand(
                item.ItemId,
                item.Title,
                item.Slug,
                item.Summary,
                item.SKU,
                item.Price,
                item.Quantity,
                item.Recipe,
                item.Instruction
            ));
        }
    }
}