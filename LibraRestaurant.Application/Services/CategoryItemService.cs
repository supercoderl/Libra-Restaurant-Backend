using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Categories.GetAll;
using LibraRestaurant.Application.Queries.Categories.GetCategoryById;
using LibraRestaurant.Application.ViewModels.Categories;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Commands.Categories.CreateCategory;
using LibraRestaurant.Domain.Commands.Categories.DeleteCategory;
using LibraRestaurant.Domain.Commands.Categories.UpdateCategory;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.CategoryItems;
using LibraRestaurant.Domain.Commands.CategoryItems.CreateCategoryItem;
using LibraRestaurant.Domain.Commands.CategoryItems.UpdateCategoryItem;
using LibraRestaurant.Domain.Commands.CategoryItems.DeleteCategoryItem;

namespace LibraRestaurant.Application.Services
{
    public class CategoryItemService : ICategoryItemService
    {
        private readonly IMediatorHandler _bus;

        public CategoryItemService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<int> CreateCategoryItemAsync(CreateCategoryItemViewModel categoryItem)
        {
            await _bus.SendCommandAsync(new CreateCategoryItemCommand(
                0,
                categoryItem.CategoryId,
                categoryItem.ItemId,
                categoryItem.Description));

            return 0;
        }

        public async Task UpdateCategoryItemAsync(UpdateCategoryItemViewModel categoryItem)
        {
            await _bus.SendCommandAsync(new UpdateCategoryItemCommand(
                categoryItem.CategoryItemId,
                categoryItem.CategoryId,
                categoryItem.ItemId,
                categoryItem.Description));
        }

        public async Task DeleteCategoryItemAsync(int categoryItemId)
        {
            await _bus.SendCommandAsync(new DeleteCategoryItemCommand(categoryItemId));
        }
    }
}
