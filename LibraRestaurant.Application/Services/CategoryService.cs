using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.Queries.Currencies.GetAll;
using LibraRestaurant.Application.Queries.Currencies.GetCurrencyById;
using LibraRestaurant.Application.ViewModels.Currencies;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Commands.Currencies.CreateCurrency;
using LibraRestaurant.Domain.Commands.Currencies.DeleteCurrency;
using LibraRestaurant.Domain.Commands.Currencies.UpdateCurrency;
using LibraRestaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Application.Queries.Categories.GetCategoryById;
using LibraRestaurant.Application.Queries.Categories.GetAll;
using LibraRestaurant.Application.ViewModels.Categories;
using LibraRestaurant.Domain.Commands.Categories.CreateCategory;
using LibraRestaurant.Domain.Commands.Categories.UpdateCategory;
using LibraRestaurant.Domain.Commands.Categories.DeleteCategory;

namespace LibraRestaurant.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMediatorHandler _bus;

        public CategoryService(IMediatorHandler bus)
        {
            _bus = bus;
        }

        public async Task<CategoryViewModel?> GetCategoryByIdAsync(int categoryId)
        {
            return await _bus.QueryAsync(new GetCategoryByIdQuery(categoryId));
        }

        public async Task<PagedResult<CategoryViewModel>> GetAllCategoriesAsync(
            PageQuery query,
            bool includeDeleted,
            string searchTerm = "",
            SortQuery? sortQuery = null)
        {
            return await _bus.QueryAsync(new GetAllCategoriesQuery(query, includeDeleted, searchTerm, sortQuery));
        }

        public async Task<int> CreateCategoryAsync(CreateCategoryViewModel category)
        {
            await _bus.SendCommandAsync(new CreateCategoryCommand(
                0,
                category.Name,
                category.Description,
                true,
                category.Picture));

            return 0;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryViewModel category)
        {
            await _bus.SendCommandAsync(new UpdateCategoryCommand(
                category.CategoryId,
                category.Name,
                category.Description,
                category.IsActive,
                category.Picture));
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _bus.SendCommandAsync(new DeleteCategoryCommand(categoryId));
        }
    }
}
