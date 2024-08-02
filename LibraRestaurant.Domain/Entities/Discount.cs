using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Domain.Entities
{
    public class Discount : Entity
    {
        public int DiscountId { get; private set; }
        public int DiscountTypeId { get; private set; }
        public int CategoryId { get; private set; }
        public int ItemId { get; private set; }
        public string? Comments { get; private set; }

        public Discount(
            int discountId,
            int discountTypeId,
            int categoryId,
            int itemId,
            string? comment
        ) : base (discountId)
        {
            DiscountId = discountId;
            DiscountTypeId = discountTypeId;
            CategoryId = categoryId;
            ItemId = itemId;
            Comments = comment;
        }

        public void SetDiscountTypeId( int discountTypeId )
        {
            DiscountTypeId = discountTypeId;
        }

        public void SetCategoryId( int categoryId )
        {
            CategoryId = categoryId;
        }

        public void SetItemId( int itemId )
        {
            ItemId = itemId;
        }

        public void SetComments( string? comments )
        {
            Comments = comments;
        }
    }
}
