using LibraRestaurant.Api.Models;
using LibraRestaurant.Api.Swagger;
using LibraRestaurant.Application.Interfaces;
using LibraRestaurant.Application.SortProviders;
using LibraRestaurant.Application.ViewModels.Menus;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Application.ViewModels;
using LibraRestaurant.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using LibraRestaurant.Application.ViewModels.Categories;
using LibraRestaurant.Domain.Entities;

namespace LibraRestaurant.Api.Controllers
{
    [ApiController]
    /*    [Authorize]*/
    [Route("/api/v1/[controller]")]
    public sealed class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            INotificationHandler<DomainNotification> notifications,
            ICategoryService categoryService) : base(notifications)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [SwaggerOperation("Get a list of all categories")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<PagedResult<CategoryViewModel>>))]
        public async Task<IActionResult> GetAllMenusAsync(
            [FromQuery] PageQuery query,
            [FromQuery] string searchTerm = "",
            [FromQuery] bool includeDeleted = false,
            [FromQuery] [SortableFieldsAttribute<CategoryViewModelSortProvider, CategoryViewModel, Category>]
        SortQuery? sortQuery = null)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(
                query,
                includeDeleted,
                searchTerm,
                sortQuery);
            return Response(categories);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get a category by id")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<CategoryViewModel>))]
        public async Task<IActionResult> GetCategoryByIdAsync([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Response(category);
        }

        [HttpPost]
        [SwaggerOperation("Create a new category")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<int>))]
        public async Task<IActionResult> CreateMenuAsync([FromBody] CreateCategoryViewModel viewModel)
        {
            var categoryId = await _categoryService.CreateCategoryAsync(viewModel);
            return Response(categoryId);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a category")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<int>))]
        public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Response(id);
        }

        [HttpPut]
        [SwaggerOperation("Update a category")]
        [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<UpdateCategoryViewModel>))]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] UpdateCategoryViewModel viewModel)
        {
            await _categoryService.UpdateCategoryAsync(viewModel);
            return Response(viewModel);
        }
    }
}
