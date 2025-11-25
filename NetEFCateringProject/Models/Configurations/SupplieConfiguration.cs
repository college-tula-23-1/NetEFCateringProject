using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFCateringProject.Models.Configurations
{
    public class SupplieConfiguration : IEntityTypeConfiguration<Supplie>
    {
        public void Configure(EntityTypeBuilder<Supplie> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasIndex(s => new { s.DateTime, s.ProviderId })
                   .IsUnique();

            builder.HasOne(s => s.Provider)
                   .WithMany(p => p.Supplies)
                   .HasForeignKey(s => s.ProviderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.DateTime)
                   .HasDefaultValueSql("SYSDATETIME()");

        }
    }
}
