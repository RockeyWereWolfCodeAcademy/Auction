using Auction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Configurations;

public class BidConfiguration : IEntityTypeConfiguration<Bid>
{
    public void Configure(EntityTypeBuilder<Bid> builder)
    {
        builder.HasOne(x => x.Item)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.ItemId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.Bidder)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.BidderId);
        builder.Property(x => x.Amount)
            .IsRequired()
            .HasColumnType("money");
    }
}
