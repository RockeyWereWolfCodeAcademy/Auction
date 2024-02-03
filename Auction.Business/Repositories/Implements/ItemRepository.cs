using Auction.Business.Repositories.Interfaces;
using Auction.Core.Entities;
using Auction.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Repositories.Implements;

public class ItemRepository : GenericRepository<Item>, IItemRepository
{
    public ItemRepository(AuctionContext context) : base(context)
    {
    }
}
