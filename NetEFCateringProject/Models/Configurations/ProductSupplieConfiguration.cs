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
    public class ProductSupplieConfiguration
        : IEntityTypeConfiguration<ProductSupplie>
    {
        public void Configure(EntityTypeBuilder<ProductSupplie> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.SupplieId });

            builder.HasOne(ps => ps.Product)
                   .WithMany(p => p.ProductSupplies)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ps => ps.Supplie)
                   .WithMany(s => s.ProductSupplies)
                   .HasForeignKey(ps => ps.SupplieId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ps => ps.Volume)
                   .HasColumnType("DECIMAL(10,2)");

            builder.ToTable(t => t.HasCheckConstraint("CK_ProductSupplies_Volume", "[Volume] > 0"));
        }
    }
}
