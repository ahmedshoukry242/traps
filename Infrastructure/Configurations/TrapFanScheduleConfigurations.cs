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
    public class TrapFanScheduleConfigurations : IEntityTypeConfiguration<TrapFanSchedule>
    {
        public void Configure(EntityTypeBuilder<TrapFanSchedule> builder)
        {
            builder.ToTable("TrapFanSchedules");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trap)
                .WithMany(x => x.TrapFanSchedules).HasForeignKey(x => x.TrapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
