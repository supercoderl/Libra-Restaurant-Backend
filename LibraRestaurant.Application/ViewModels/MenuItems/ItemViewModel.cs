using LibraRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.ViewModels.MenuItems
{
    public sealed class ItemViewModel
    {
        public int ItemId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Summary {  get; set; }
        public string SKU { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Recipe { get; set; }
        public string? Instruction { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }

        public static ItemViewModel FromItem(MenuItem item)
        {
            return new ItemViewModel
            {
                ItemId = item.ItemId,
                Title = item.Title,
                Slug = item.Slug,
                Summary = item.Summary,
                SKU = item.SKU,
                Price = item.Price,
                Quantity = item.Quantity,
                Recipe = item.Recipe,
                Instruction = item.Instruction,
                CreatedAt = item.CreatedAt,
                LastUpdatedAt = item.LastUpdatedAt,
            };
        }
    }
}
