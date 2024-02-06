using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Roles;

public class RoleAssignFailedException : Exception, IBaseException
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status409Conflict;
    public RoleAssignFailedException() 
    {
        ErrorMessage = "Role assign failed";
    }
    public RoleAssignFailedException(string message)
    {
        ErrorMessage = message;
    }
}
