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
    public class TrapValveQutScheduleConfigurations : IEntityTypeConfiguration<TrapValveQutSchedule>
    {
        public void Configure(EntityTypeBuilder<TrapValveQutSchedule> builder)
        {
            builder.ToTable("TrapValveQutSchedules");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Trap).WithMany(x => x.TrapValveQutSchedules)
                .HasForeignKey(x => x.TrapId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
