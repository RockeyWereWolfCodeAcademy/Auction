using Auction.Business.DTOs.ItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces;

public interface IItemService
{
    public IEnumerable<ItemListDTO> GetAll();
    public Task<ItemDetailsDTO> GetByIdAsync(int id);
    public Task CreateAsync(ItemCreateDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, ItemUpdateDTO dto);
    public Task SoftDelete(int id);
    public Task ReverseSoftDelete(int id);
}
