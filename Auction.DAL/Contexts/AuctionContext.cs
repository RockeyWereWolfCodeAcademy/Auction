using Auction.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DAL.Contexts;

public class AuctionContext : IdentityDbContext<AppUser>
{
    public AuctionContext(DbContextOptions options) : base(options) { }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Bid> Bids { get; set; }
    public DbSet<ItemImage> ItemImages { get; set; }
    public DbSet<ActivityLog> ActivityLogs { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var bids = ChangeTracker.Entries<Bid>();
        foreach (var bid in bids)
        {
            if (bid.State == EntityState.Added)
                bid.Entity.BidTime = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
