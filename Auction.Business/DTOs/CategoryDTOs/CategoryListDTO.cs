using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.DTOs.CategoryDTOs;

public class CategoryListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParentCategoryId { get; set; }
    public bool IsDeleted { get; set; }
}
