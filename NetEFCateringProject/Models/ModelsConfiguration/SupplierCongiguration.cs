using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.ModelsConfiguration
{
    public class SupplierCongiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(cd => cd.Id);
            builder.HasIndex(cd => cd.Name)
                   .IsUnique();
            builder.Property(cd => cd.Name)
                   .HasMaxLength(100);
            builder.Property(cd => cd.Name)
                   .IsRequired();
        }
    }
}
