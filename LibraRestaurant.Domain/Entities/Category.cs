using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class Category : Entity
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public bool IsActive { get; private set; }

        public Category(
            int categoryId,
            string name,
            string? description,
            bool isActive
        ) : base( categoryId )
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public void SetName(string name )
        {
            Name = name;
        }

        public void SetDescription(string? description )
        {
            Description = description;
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }
    }
}
