using Auction.Business.DTOs.CategoryDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Profiles;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        CreateMap<ItemCreateDTO, Item>()
            .ForMember(i => i.Images, opt => opt.Ignore());
        CreateMap<ItemUpdateDTO, Item>()
            .ForMember(i => i.Images, opt => opt.Ignore());
        CreateMap<Item, ItemListDTO>()
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(i => i.Category.Name))
            .ForMember(dto => dto.SellerUsername, opt => opt.MapFrom(i => i.Seller.UserName));
        CreateMap<Item, ItemDetailsDTO>()
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(i => i.Category.Name))
            .ForMember(dto => dto.SellerUsername, opt => opt.MapFrom(i => i.Seller.UserName));
    }
}
