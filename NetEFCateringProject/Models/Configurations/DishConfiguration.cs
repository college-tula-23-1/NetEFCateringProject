using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(d => d.Name)
                   .IsUnique();

            builder.ToTable(t => t.HasCheckConstraint("CK_Dishes_Price", "[price] > 0"));

            builder.Property(d => d.IsActive)
                   .HasDefaultValue(true);

            builder.HasOne(d => d.Category)
                   .WithMany(c => c.Dishes)
                   .HasForeignKey(d => d.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
