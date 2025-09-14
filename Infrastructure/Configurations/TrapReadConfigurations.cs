using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

            builder.HasOne(x => x.Trap).WithMany(x => x.trapReads).HasForeignKey(x => x.TrapId).IsRequired();
        }
    }
}
