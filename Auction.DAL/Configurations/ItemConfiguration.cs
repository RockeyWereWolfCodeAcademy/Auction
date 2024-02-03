using Auction.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1024);
        builder.Property(x => x.StartingPrice)
            .IsRequired()
            .HasColumnType("money");
        builder.Property(x => x.CurrentPrice)
            .IsRequired()
            .HasColumnType("money");
        builder.Property(x => x.StartingTime)
            .IsRequired();
        builder.Property(x => x.EndingTime)
            .IsRequired();
        builder.HasOne(x => x.Seller)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.SellerId);
    }
}
