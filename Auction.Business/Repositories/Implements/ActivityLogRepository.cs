using Auction.Business.Repositories.Interfaces;
using Auction.Core.Entities;
using Auction.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories.Implements;

public  class ActivityLogRepository : IActivityLogRepository
{
    readonly AuctionContext _context;

    public ActivityLogRepository(AuctionContext context)
    {
        _context = context;
    }

    public DbSet<ActivityLog> Table => _context.Set<ActivityLog>();

    public IQueryable<ActivityLog> GetAll(bool notTracked = true, params string[] includes)
    {
        var data = Table.AsQueryable();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                data = data.Include(include);
            }
        }
        return notTracked ? data.AsNoTracking() : data;
    }
}
