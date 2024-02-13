using Auction.Business.DTOs.BidDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Profiles;

public class BidMappingProfile : Profile
{
    public BidMappingProfile()
    {
        CreateMap<BidCreateDTO, Bid>();
        CreateMap<BidUpdateDTO, Bid>();
        CreateMap<Bid, BidListDTO>()
            .ForMember(dto => dto.ItemName, opt => opt.MapFrom(b => b.Item.Name))
            .ForMember(dto => dto.BidderUsername, opt => opt.MapFrom(b => b.Bidder.UserName));
        CreateMap<Bid, BidDetailsDTO>()
            .ForMember(dto => dto.ItemName, opt => opt.MapFrom(b => b.Item.Name))
            .ForMember(dto => dto.BidderUsername, opt => opt.MapFrom(b => b.Bidder.UserName));
        CreateMap<BidDetailsDTO, BidUpdateDTO>();
    }
}
