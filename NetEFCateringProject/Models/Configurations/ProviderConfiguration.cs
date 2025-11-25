using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(p => p.Name)
                   .IsUnique();

            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);

            builder.HasMany(p => p.Supplies)
                   .WithOne(s => s.Provider);
        }
    }
}
