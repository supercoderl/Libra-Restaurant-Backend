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
    public sealed class OrderConfiguration : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder
                .HasKey(x => x.OrderId);

            builder
                .Property(order => order.OrderNo)
                .IsRequired();

            builder
                .Property(order => order.StoreId)
                .IsRequired();

            builder
                .Property(order => order.PaymentMethodId)
                .IsRequired();

            builder
                .Property(order => order.PaymentTimeId)
                .IsRequired();

            builder
                .Property(order => order.ServantId)
                .IsRequired();

            builder
                .Property(order => order.CashierId)
                .IsRequired();

            builder
                .Property(order => order.CustomerNotes);

            builder
                .Property(order => order.ReservationId)
                .IsRequired();

            builder
                .Property(order => order.PriceCalculated)
                .IsRequired();

            builder
                .Property(order => order.PriceAdjustment);

            builder
                .Property(order => order.PriceAdjustmentReason);

            builder
                .Property(order => order.Subtotal)
                .IsRequired();

            builder
                .Property(order => order.Tax)
                .IsRequired();

            builder
                .Property(order => order.Total)
                .IsRequired();

            builder
                .Property(order => order.LatestStatus)
                .IsRequired();

            builder
                .Property(order => order.LatestStatusUpdate)
                .IsRequired();

            builder
                .Property(order => order.IsPaid)
                .IsRequired()
                .HasColumnType("bit");

            builder
                .Property(order => order.IsPreparationDelayed)
                .IsRequired()
                .HasColumnType("bit");

            builder
                .Property(order => order.DelayedTime);

            builder
                .Property(order => order.IsCanceled)
                .IsRequired()
                .HasColumnType("bit");

            builder
                .Property(order => order.CanceledTime);

            builder
                .Property(order => order.CanceledReason);

            builder
                .Property(order => order.IsReady)
                .IsRequired()
                .HasColumnType("bit");

            builder
                .Property(order => order.ReadyTime);

            builder
                .Property(order => order.IsCompleted)
                .IsRequired()
                .HasColumnType("bit");

            builder
                .Property(order => order.CompletedTime);

            builder.HasData(new OrderHeader(
                Ids.Seed.UserId,
                "00000001",
                Guid.NewGuid(),
                1,
                1,
                Guid.NewGuid(),
                Guid.NewGuid(),
                null,
                1,
                1000000,
                null,
                null,
                1000000,
                10,
                1100000,
                string.Empty,
                string.Empty,
                false,
                false,
                null,
                false,
                null,
                null,
                true,
                DateTime.Now,
                false,
                null));
        }
    }
}
