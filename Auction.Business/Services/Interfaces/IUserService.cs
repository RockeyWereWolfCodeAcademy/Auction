using Auction.Business.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDTO dto);
    }
}
