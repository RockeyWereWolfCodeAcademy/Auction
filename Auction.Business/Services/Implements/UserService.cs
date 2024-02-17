using Auction.Business.DTOs.ActivityLogDTOs;
using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.DTOs.UserDTOs;
using Auction.Business.Exceptions.AppUser;
using Auction.Business.Exceptions.Roles;
using Auction.Business.Repositories.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Entities;
using Auction.Core.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Implements;

public class UserService : IUserService
{
    readonly IMapper _mapper;
    readonly UserManager<AppUser> _userManager;
    readonly IActivityLogRepository _activityRepo;

    public UserService(IMapper mapper, UserManager<AppUser> userManager, IActivityLogRepository activityRepo)
    {
        _mapper = mapper;
        _userManager = userManager;
        _activityRepo = activityRepo;
    }

    public async Task CreateAsync(RegisterDTO dto)
    {
        var user = _mapper.Map<AppUser>(dto);
        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            StringBuilder sb = new();
            foreach (var error in result.Errors)
            {
                sb.Append(error.Code + error.Description + " ");
            }
            throw new AppUserCreationFailedException(sb.ToString().TrimEnd());
        }
        var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Member));
        if (!roleResult.Succeeded)
        {
            StringBuilder sb = new();
            foreach (var error in result.Errors)
            {
                sb.Append(error.Description + " ");
            }
            throw new RoleAssignFailedException(sb.ToString().TrimEnd());
        }
    }

    public IEnumerable<AppUserListDTO> GetAllUsers()
    {
        return _mapper.Map<IEnumerable<AppUserListDTO>>(_userManager.Users);
    }

    public IEnumerable<ActivityLogListDTO> GetActivityLogByUserId(string userId)
    {
        return _mapper.Map<IEnumerable<ActivityLogListDTO>>(_activityRepo.GetAll().Where(a => a.UserId == userId));
    }
}
