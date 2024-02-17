using Auction.Business.DTOs.ActivityLogDTOs;
using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces;

public interface IUserService
{
    public Task CreateAsync(RegisterDTO dto);

    public IEnumerable<AppUserListDTO> GetAllUsers();

    public IEnumerable<ActivityLogListDTO> GetActivityLogByUserId (string userId);
}
