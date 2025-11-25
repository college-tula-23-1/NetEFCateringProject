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
    public class ProductDishConfiguration : IEntityTypeConfiguration<ProductDish>
    {
        public void Configure(EntityTypeBuilder<ProductDish> builder)
        {
            builder.HasKey(pd => new { pd.ProductId, pd.DishId });

            builder.HasOne(pd => pd.Product)
                   .WithMany(p => p.ProductDishes)
                   .HasForeignKey(pd => pd.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pd => pd.Dish)
                   .WithMany(d => d.ProductDishes)
                   .HasForeignKey(d => d.DishId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
