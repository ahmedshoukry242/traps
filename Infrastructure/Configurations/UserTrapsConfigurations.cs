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
    public class UserTrapsConfigurations : IEntityTypeConfiguration<UserTraps>
    {
        public void Configure(EntityTypeBuilder<UserTraps> builder)
        {
            builder.ToTable("UserTraps");
            builder.HasKey(t => t.Id);

            builder.HasIndex(x => new { x.UserId, x.TrapId }).IsUnique();

            builder.HasOne(x => x.User).WithMany(x => x.UserTraps).HasForeignKey(x => x.UserId).IsRequired();
            builder.HasOne(x => x.Trap).WithMany(x => x.UserTraps).HasForeignKey(x => x.TrapId).IsRequired();
        }
    }
}
