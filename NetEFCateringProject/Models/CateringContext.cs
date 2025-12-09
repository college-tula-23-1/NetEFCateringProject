using Microsoft.EntityFrameworkCore;
using NetEFCateringProject.Models.Configurations;
using NetEFCateringProject.Models.MiddleEntities;
using NetEFCateringProject.Models.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models
{
    public class CateringContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<DishCategory> DishCategories { get; set; } = null!;
        public DbSet<Unit> Units { get; set; } = null!;

        public DbSet<Provider> Providers { get; set; } = null!;
        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Supplie> Supplies { get; set; } = null!;

        //public DbSet<ProductProvider> ProductsProviders { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=WS-TC-1-3-00;Initial Catalog=catering_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DishCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            modelBuilder.ApplyConfiguration(new ProviderConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SupplieConfiguration());

            modelBuilder.ApplyConfiguration(new ProductDishConfiguration());
            modelBuilder.ApplyConfiguration(new ProductProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSupplieConfiguration());
            
        }
    }
}
