using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebApplication2.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var implementedConfigTypes = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(type => !type.IsAbstract
                                        && !type.IsGenericTypeDefinition
                                        && type.GetTypeInfo().ImplementedInterfaces
                                        .Any(implementedInterfaces => implementedInterfaces.GetTypeInfo().IsGenericType
                                        && implementedInterfaces.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configInfo in implementedConfigTypes)
            {
                //Guess what doesn't compile?
                dynamic mapInstance = Activator.CreateInstance(configInfo);
                modelBuilder.ApplyConfiguration(mapInstance);
            }
        }
    }
}
