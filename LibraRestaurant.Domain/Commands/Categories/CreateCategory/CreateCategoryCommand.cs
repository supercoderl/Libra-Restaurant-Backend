
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Commands.Categories.CreateCategory
{
    public sealed class CreateCategoryCommand : CommandBase
    {
        private static readonly CreateCategoryCommandValidation s_validation = new();

        public int CategoryId { get; }
        public string Name { get; }
        public string? Description { get; }
        public bool IsActive { get; }

        public CreateCategoryCommand(
            int categoryId,
            string name,
            string? description,
            bool isActive
        ) : base(categoryId)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            IsActive = isActive;
        }

        public override bool IsValid()
        {
            ValidationResult = s_validation.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
