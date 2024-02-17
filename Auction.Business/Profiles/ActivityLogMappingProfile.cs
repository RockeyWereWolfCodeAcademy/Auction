using Auction.Business.DTOs.ActivityLogDTOs;
using Auction.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Profiles;

public class ActivityLogMappingProfile : Profile
{
    public ActivityLogMappingProfile()
    {
        CreateMap<ActivityLog, ActivityLogListDTO>();
    }
}
