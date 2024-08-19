using LibraRestaurant.Domain.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraRestaurant.Domain.Entities;

namespace LibraRestaurant.Infrastructure.Configurations
{
    public sealed class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasKey(x => x.PaymentMethodId);

            builder
                .Property(menu => menu.Name)
                .IsRequired();

            builder
                .Property(menu => menu.Description);

            builder
                .Property(menu => menu.IsActive)
                .IsRequired()
                .HasColumnType("bit");
        }
    }
}
