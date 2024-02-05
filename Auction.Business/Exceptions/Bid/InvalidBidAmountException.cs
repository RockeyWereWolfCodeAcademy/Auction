using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Bid;

public class InvalidBidAmountException : Exception
{
    public InvalidBidAmountException() : base("Invalid bid amount, check are there anotther bids on this item") { }
    public InvalidBidAmountException(string? message) : base(message) { }

}
