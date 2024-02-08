using Auction.Business.DTOs.BidDTOs;
using Auction.Business.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Interfaces;

public interface IBidService
{
    public IEnumerable<BidListDTO> GetAll();
    public Task<BidDetailsDTO> GetByIdAsync(int id);
    public Task CreateAsync(BidCreateDTO dto);
    public Task DeleteAsync(int id);
    public Task UpdateAsync(int id, BidUpdateDTO dto);
    public Task SoftDelete(int id);
    public Task ReverseSoftDelete(int id);
}
