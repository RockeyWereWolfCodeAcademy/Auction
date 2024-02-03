using Auction.Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces;

public interface ICategoryService
{
    public IEnumerable<CategoryListDTO> GetAll();
    public Task<CategoryDetailsDTO> GetByIdAsync(int id);
    public Task CreateAsync(CategoryCreateDTO topic);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, CategoryUpdateDTO topic);
}
