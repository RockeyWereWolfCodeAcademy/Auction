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

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Exception)
            .IsRequired(false);

        builder.Property(p => p.Properties)
            .IsRequired(false);

        builder.Property(p => p.LogEvent)
            .IsRequired(false);

        builder.Property(p => p.TimeStamp)
            .HasColumnType("datetime");

        builder.Property(p => p.Level)
            .HasMaxLength(16);
    }
}
