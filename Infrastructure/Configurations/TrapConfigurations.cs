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
    public class TrapConfigurations : IEntityTypeConfiguration<Trap>
    {
        public void Configure(EntityTypeBuilder<Trap> builder)
        {
            builder.ToTable("Traps");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.SerialNumber).HasFilter("[SerialNumber] IS NOT NULL");

            builder.Property(x => x.Iema).IsRequired(false);
            builder.Property(x => x.ValveQut).IsRequired(false);
            builder.Property(x => x.Fan).IsRequired(false);


            // NOTE: create a class implement [ValueConverter] with his default constructor
            //builder.Property(x => x.FileDate).HasConversion(new ValueConverter<DateOnly, DateTime>(dateOnly=>dateOnly.ToDateTime(TimeOnly.MinValue),dateTime=>DateOnly.FromDateTime(dateTime)));
            builder.Property(x => x.ReadingDate)
                .HasConversion(new ValueConverter<DateOnly, DateTime>(dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue), dateTime => DateOnly.FromDateTime(dateTime)))
                .IsRequired(false);

            builder.HasOne(x=>x.Country).WithMany(x=>x.Traps).HasForeignKey(x => x.CountryId).IsRequired(false);
            builder.HasOne(x=>x.State).WithMany(x => x.Traps).HasForeignKey(x => x.CountryId).IsRequired(false);
            builder.HasOne(x=>x.Category).WithMany(x=>x.Traps).HasForeignKey(x=>x.CategoryId).IsRequired(false);
            builder.HasMany(x => x.TrapEmergencies).WithOne(x => x.Trap).HasForeignKey(x => x.TrapId).IsRequired();
        }
    }
}
