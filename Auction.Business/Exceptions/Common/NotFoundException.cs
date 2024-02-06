using Auction.Core.Entities.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Common;

public class NotFoundException<T> : Exception, IBaseException where T : BaseEntity
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status404NotFound;
    public NotFoundException()
    {
        ErrorMessage = typeof(T).Name + " not found";
    }
    public NotFoundException(string? message)
    {
        ErrorMessage = message;
    }

}
