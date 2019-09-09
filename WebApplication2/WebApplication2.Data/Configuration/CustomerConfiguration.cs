using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication2.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id).ValueGeneratedOnAdd();





            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Name = "John",
                    Address = "USA"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mike",
                    Address = "USA"
                }, new Customer
                {
                    Id = 3,
                    Name = "Kumar",
                    Address = "India"
                }, new Customer
                {
                    Id = 4,
                    Name = "Bruclee",
                    Address = "HK"
                },
                new Customer
                {
                    Id = 5,
                    Name = "Kavari",
                    Address = "Moldives"
                }
                );
        }
    }
}
