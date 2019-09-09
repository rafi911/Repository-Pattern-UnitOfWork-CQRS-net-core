using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(orderItem => orderItem.ProductId);
            builder.Property(orderItem => orderItem.ProductId).ValueGeneratedNever();

            builder.HasOne(entity => entity.Order)
                .WithMany(entity => entity.OrderItem)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
