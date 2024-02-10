using Auction.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Configurations;

public class ItemImageConfiguration : IEntityTypeConfiguration<ItemImage>
{
    public void Configure(EntityTypeBuilder<ItemImage> builder)
    {
        builder.HasOne(x => x.Item)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.ItemId);
        builder.Property(x => x.ImageData)
            .IsRequired();
    }
}
