using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.BidDTOs;

public class BidDetailsDTO
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string BidderId { get; set; }
    public string BidderUsername { get; set; }
    public decimal Amount { get; set; }
    public DateTime BidTime { get; set; }
    public bool IsDeleted { get; set; }
}
