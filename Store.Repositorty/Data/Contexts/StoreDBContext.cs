using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Core.Entities;
using Store.Core.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repositorty.Data.Contexts
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductType> Types { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> Items { get; set; }
        public DbSet<DelevaryMethod> DelevaryMethods { get; set; }
        public DbSet<ProductItemOrder> ProductItemOrders { get; set; } // إضافة DbSet
    }
}
