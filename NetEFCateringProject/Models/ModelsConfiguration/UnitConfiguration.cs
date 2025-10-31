using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.ModelsConfiguration
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {

            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Name)
                   .IsUnique();
            builder.Property(u => u.Name)
                   .HasMaxLength(50);
        }
    }
}
