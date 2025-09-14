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
    public class TrapCounterScheduleConfigurations : IEntityTypeConfiguration<TrapCounterSchedule>
    {
        public void Configure(EntityTypeBuilder<TrapCounterSchedule> builder)
        {
            builder.ToTable("TrapCounterSchedules");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trap)
                .WithMany(x => x.TrapCounterSchedules).HasForeignKey(x => x.TrapId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
