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
    public sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .HasKey(x => x.StoreId);
                
            builder
                .Property(store => store.Name)
                .IsRequired();

            builder
                .Property(store => store.StoreId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder
                .Property(store => store.CityId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(store => store.DistrictId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(store => store.WardId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(store => store.TaxCode);

            builder
                .Property(store => store.Address)
                .IsRequired();

            builder
                .Property(store => store.GpsLocation);

            builder
                .Property(store => store.PostalCode);

            builder
                .Property(store => store.Phone);

            builder
                .Property(store => store.Fax);

            builder
                .Property(store => store.Email);

            builder
                .Property(store => store.Website);

            builder
                .Property(store => store.Logo);

            builder
                .Property(store => store.BankBranch);

            builder
                .Property(store => store.BankCode);

            builder
                .Property(store => store.BankAccount);

            builder
                .Property(store => store.IsActive)
                .IsRequired()
                .HasColumnType("bit");

            builder.HasData(new Store(
                Ids.Seed.UserId,
                "Nhà hàng Libra - Chi nhánh 1",
                1,
                1,
                1,
                true,
                null,
                string.Empty,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null));
        }
    }
}
