using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetEFCateringProject.Models.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class ProductCategoryConfiguration
        : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(c => c.Name)
                   .IsUnique();

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category);
        }
    }
}
