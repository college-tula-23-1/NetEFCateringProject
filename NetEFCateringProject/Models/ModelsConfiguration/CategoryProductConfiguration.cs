using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.ModelsConfiguration
{
    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(cd => cd.Id);
            builder.HasIndex(cd => cd.Name)
                   .IsUnique();
            builder.Property(cd => cd.Name)
                   .HasMaxLength(50);
            builder.Property(cd => cd.Name)
                   .IsRequired();
        }
    }
}
