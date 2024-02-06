using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.Auth;

public class LoginFailedException : Exception, IBaseException
{
    public string ErrorMessage { get; set; }
    public int StatusCode => StatusCodes.Status400BadRequest;
    public LoginFailedException() 
    {
        ErrorMessage = "Login failed. Check your credentials!";
    }
    public LoginFailedException(string message) 
    {
        ErrorMessage = message;
    }
}
