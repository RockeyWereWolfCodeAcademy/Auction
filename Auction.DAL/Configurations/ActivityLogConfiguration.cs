using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auction.Core.Entities;

namespace Auction.DAL.Configurations;

public class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        builder.Property(p => p.Level)
            .HasMaxLength(16);

        builder.HasOne(x => x.User)
            .WithMany(x => x.ActivityLogs)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Item)
            .WithMany(x => x.ActivityLogs)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(x => x.ItemId);
    }
}
