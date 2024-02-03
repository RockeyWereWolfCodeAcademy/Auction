using Auction.Business.DTOs.CategoryDTOs;
using Auction.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Profiles;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<CategoryCreateDTO, Category>()/*.ForMember(c => c.ParentCategoryId, opt => opt.MapFrom(dto => dto.ParentCategoryId))*/;
        CreateMap<CategoryUpdateDTO, Category>()/*.ForMember(c => c.ParentCategoryId, opt => opt.MapFrom(dto => dto.ParentCategoryId))*/;
        CreateMap<Category, CategoryListDTO>();
        CreateMap<Category, CategoryDetailsDTO>()/*.ForMember(dto => dto.ChildCategories, opt => opt.MapFrom(c => c.ChildCategories))*/;
    }
}
