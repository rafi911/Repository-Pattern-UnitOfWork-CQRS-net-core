using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "T-Shirt",
                    Price = 1200
                },
                new Product
                {
                    Id = 2,
                    Name = "Shirt",
                    Price = 2000
                },
                new Product
                {
                    Id = 3,
                    Name = "Inner wear",
                    Price = 700
                },
                new Product
                {
                    Id = 4,
                    Name = "Shoe",
                    Price = 5000
                },
                new Product
                {
                    Id = 5,
                    Name = "belt",
                    Price = 1000
                }
                );
        }
    }
}
