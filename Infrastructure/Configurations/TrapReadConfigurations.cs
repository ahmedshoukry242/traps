using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class TrapReadConfigurations : IEntityTypeConfiguration<TrapRead>
    {
        public void Configure(EntityTypeBuilder<TrapRead> builder)
        {
            builder.ToTable("TrapReads");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.TrapId, x.Date }).IsUnique();

            // Add DateOnly value converters
            builder.Property(x => x.Date)
                .HasConversion(new ValueConverter<DateOnly, DateTime>(
                    dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime)));

            builder.Property(x => x.ServerCreationDate)
                .HasConversion(new ValueConverter<DateOnly, DateTime>(
                    dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
                    dateTime => DateOnly.FromDateTime(dateTime)));

            builder.HasOne(x => x.Trap).WithMany(x => x.trapReads).HasForeignKey(x => x.TrapId).IsRequired();
        }
    }
}
