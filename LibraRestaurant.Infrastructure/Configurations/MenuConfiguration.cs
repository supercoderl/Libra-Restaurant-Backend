using LibraRestaurant.Domain.Constants;
using LibraRestaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Infrastructure.Configurations
{
    public sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder
                .HasKey(x => x.MenuId);

            builder
                .Property(menu => menu.Name)
                .IsRequired();

            builder
                .Property(menu => menu.StoreId)
                .IsRequired();

            builder
                .Property(menu => menu.Description);

            builder
                .Property(menu => menu.IsActive)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasData(new Menu(
                Ids.Seed.NumberId,
                Guid.NewGuid(),
                "Menu nhà hàng Libra chi nhánh 1",
                null,
                true));
        }
    }
}
