using NetEFCateringProject.Models.References;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetEFCateringProject.Models.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(u => u.Name)
                   .IsUnique();

            builder.Property(u => u.Abbr)
                   .HasMaxLength(10)
                   .IsRequired();
            builder.HasIndex(u => u.Abbr)
                   .IsUnique();

            builder.HasMany(u => u.Products)
                   .WithOne(p => p.Unit);
        }
    }
}
