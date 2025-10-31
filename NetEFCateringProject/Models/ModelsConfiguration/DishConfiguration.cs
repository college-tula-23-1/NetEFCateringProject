using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.ModelsConfiguration
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => d.Name)
                   .IsUnique();
            builder.Property(d => d.Name)
                   .HasMaxLength(100);
            builder.Property(d => d.Price)
                   .HasPrecision(10, 2);
                   //.HasColumnType("DECIMAL(10,2)");

            builder.HasOne(d => d.Category)
                   .WithMany(cd => cd.Dishes)
                   .HasForeignKey(d => d.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);
                   
        }
    }
}
