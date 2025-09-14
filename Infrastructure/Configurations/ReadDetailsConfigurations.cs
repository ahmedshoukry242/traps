using AutoMapper.Execution;
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
    public class ReadDetailsConfigurations : IEntityTypeConfiguration<ReadDetails>
    {
        public void Configure(EntityTypeBuilder<ReadDetails> builder)
        {
            builder.ToTable("ReadDetails");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.Time, x.TrapReadId }).IsUnique();
            builder.Property(x => x.Time).HasConversion(new ValueConverter<TimeOnly, TimeSpan>(timeOnly => timeOnly.ToTimeSpan(), timeSpan => TimeOnly.FromTimeSpan(timeSpan)));
        }
    }
}
