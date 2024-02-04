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
    public CategoryRepository(AuctionContext context) : base(context)
    {
    }
}
