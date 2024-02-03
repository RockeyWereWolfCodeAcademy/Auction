using Auction.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.CategoryDTOs;

public class CategoryDetailsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<CategoryListDTO>? ChildCategories { get; set; }
    //public IEnumerable<string>? ChildCategoryNames { get; set; }
}
