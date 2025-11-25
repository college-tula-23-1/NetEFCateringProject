using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(p => p.Name)
                   .IsUnique();

            builder.ToTable(t => t.HasCheckConstraint(
                "CK_Products_Name", "[ShelfLife] > 0"));

            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Unit)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.UnitId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
