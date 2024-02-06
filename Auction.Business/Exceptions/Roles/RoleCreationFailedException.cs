using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Roles;

public class RoleCreationFailedException : Exception, IBaseException
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status409Conflict;
    public RoleCreationFailedException() 
    {
        ErrorMessage = "Role creation failed";
    }
    public RoleCreationFailedException(string message)
    {
        ErrorMessage = message;
    }
}
