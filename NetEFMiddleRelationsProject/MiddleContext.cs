using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFMiddleRelationsProject
{
    public class MiddleContext : DbContext
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=WS-TC-1-3-00;Initial Catalog=college;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Provider>()
            //            .HasMany(p => p.Products)
            //            .WithMany(p => p.Providers)
            //            .UsingEntity<ProductProvider>(
            //            m => m.
            //                    HasOne(p => p.Product)
            //                    .WithMany(p => p.ProductProviders)
            //                    .HasForeignKey(pp => pp.ProductId),
            //            m => m.
            //                    HasOne(pp => pp.Provider)
            //                    .WithMany(p => p.ProductProviders)
            //                    .HasForeignKey(pp => pp.ProviderId),
            //            m =>
            //            {
            //                m.ToTable("Supplies");
            //                m.HasKey(pp => new { pp.ProductId, pp.ProviderId });
            //            }

            //    );


            modelBuilder.Entity<ProductProvider>()
                        .ToTable("Supplies");

            modelBuilder.Entity<ProductProvider>()
                        .HasKey(pp => new { pp.ProductId, pp.ProviderId });

            modelBuilder.Entity<ProductProvider>()
                        .HasOne(pp => pp.Product)
                        .WithMany(p => p.ProductProviders)
                        .HasForeignKey(pp => pp.ProductId);

            modelBuilder.Entity<ProductProvider>()
                        .HasOne(pp => pp.Provider)
                        .WithMany(p => p.ProductProviders)
                        .HasForeignKey(pp => pp.ProviderId);


        }
    }

    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; } = new();
        public List<ProductProvider> ProductProviders { get; set; } = new();

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Provider> Providers { get; set; } = new();
        public List<ProductProvider> ProductProviders { get; set; } = new();
    }

    public class ProductProvider
    {
        public Provider Provider { get; set; } = null!;
        public int ProviderId { get; set; }

        public Product Product { get; set; } = null!;
        public int ProductId { get; set; }

        public int? Price { get; set; }
    }

}
