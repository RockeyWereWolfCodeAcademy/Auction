using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Exceptions.AppUser
{
    public class AppUserCreationFailedException : Exception
    {
        public AppUserCreationFailedException() : base() { }
        public AppUserCreationFailedException(string message) : base(message) { }
    }
}
