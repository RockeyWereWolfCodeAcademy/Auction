using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.AppUser;

public class AppUserCreationFailedException : Exception, IBaseException
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status409Conflict;
    public AppUserCreationFailedException()  
    {
        ErrorMessage = "User cannot be created";
    }
    public AppUserCreationFailedException(string message) 
    {
        ErrorMessage = message;
    }
}
