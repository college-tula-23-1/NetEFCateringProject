using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEFCateringProject.Models.MiddleEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class ProductProviderConfiguration
        : IEntityTypeConfiguration<ProductProvider>
    {
        public void Configure(EntityTypeBuilder<ProductProvider> builder)
        {
            builder.HasKey(pp => new { pp.ProductId, pp.ProviderId });

            builder.HasOne(pp => pp.Product)
                   .WithMany(p => p.ProductProviders)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Provider)
                   .WithMany(p => p.ProductProviders)
                   .HasForeignKey(pp => pp.ProviderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Price)
                   .HasColumnType("DECIMAL(9,2)");
        }
    }
}
