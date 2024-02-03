using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Core.Entities;

public class Bid : BaseEntity
{
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public string BidderId { get; set; }
    public AppUser Bidder { get; set; }
    public decimal Amount { get; set; }
    public DateTime BidTime { get; set; }
}
