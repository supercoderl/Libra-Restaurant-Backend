using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class MenuItem : Entity
    {
        public int ItemId { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string? Summary { get; private set; }
        public string SKU { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public string? Recipe { get; private set; }
        public string? Instruction { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdatedAt { get; private set; }

        public MenuItem(
            int itemId,
            string title,
            string slug,
            string? summary,
            string sKU,
            double price,
            int quantity,
            string? recipe,
            string? instruction,
            DateTime createdAt,
            DateTime? lastUpdatedAt
        )
        {
            ItemId = itemId;
            Title = title;
            Slug = slug;
            Summary = summary;
            SKU = sKU;
            Price = price;
            Quantity = quantity;
            Recipe = recipe;
            Instruction = instruction;
            CreatedAt = createdAt;
            LastUpdatedAt = lastUpdatedAt;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetSlug(string slug)
        {
            Slug = slug;
        }

        public void SetSummary(string? summary)
        {
            Summary = summary;
        }

        public void SetSKU(string sKU)
        {
            SKU = sKU;
        }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public void SetRecipe(string? recipe)
        {
            Recipe = recipe;
        }

        public void SetInstruction(string? instruction)
        {
            Instruction = instruction;
        }

        public void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

        public void SetLastUpdatedAt(DateTime? lastUpdatedAt)
        {
            LastUpdatedAt = lastUpdatedAt;
        }
    }
}
