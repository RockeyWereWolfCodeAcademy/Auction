using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Bid;

public class InvalidBidAmountException : Exception, IBaseException
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status409Conflict;
    public InvalidBidAmountException()
    {
        ErrorMessage = "Invalid bid amount, check are there another bids on this item";
    }
    public InvalidBidAmountException(string? message) 
    {
        ErrorMessage = message;
    }
}
