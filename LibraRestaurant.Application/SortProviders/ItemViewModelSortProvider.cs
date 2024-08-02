using LibraRestaurant.Application.ViewModels.MenuItems;
using LibraRestaurant.Application.ViewModels.Sorting;
using LibraRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.SortProviders
{
    public sealed class ItemViewModelSortProvider : ISortingExpressionProvider<ItemViewModel, MenuItem>
    {
        private static readonly Dictionary<string, Expression<Func<MenuItem, object>>> s_expressions = new()
        {
            { "title", user => user.Title },
            { "slug", user => user.Slug },
            { "summary", user => user.Summary ?? string.Empty },
            { "sku", user => user.SKU },
            { "price", user => user.Price },
            { "quantity", user => user.Quantity },
            { "recipe", item => item.Recipe ?? string.Empty },
            { "instruction", item => item.Instruction ?? string.Empty },
            { "createdAt", item => item.CreatedAt },
            { "lastUpdatedAt", item => item.LastUpdatedAt ?? DateTime.Now }
        };

        public Dictionary<string, Expression<Func<MenuItem, object>>> GetSortingExpressions()
        {
            return s_expressions;
        }
    }
}
