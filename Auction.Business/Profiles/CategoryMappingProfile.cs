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
        CreateMap<CategoryCreateDTO, Category>();
        CreateMap<CategoryUpdateDTO, Category>();
        CreateMap<Category, CategoryListDTO>();
        CreateMap<Category, CategoryDetailsDTO>();
        CreateMap<CategoryDetailsDTO, CategoryUpdateDTO>();
    }
}
