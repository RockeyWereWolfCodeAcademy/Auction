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

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public override async Task<Category> GetByIdAsync(int id, bool noTracking = true, params string[] includes)
    {
        var data = Table.AsQueryable();
        if (includes.Any())
        {
            foreach (var include in includes)
            {
                data = data.Include(include);
            }
        }
        data = data.Include(d => d.ChildCategories);
        return noTracking ? await data.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id) : await data.SingleOrDefaultAsync(t => t.Id == id);
    }
    public CategoryRepository(AuctionContext context) : base(context)
    {
    }
}
