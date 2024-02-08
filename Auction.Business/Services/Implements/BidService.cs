using Auction.Business.DTOs.BidDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.Exceptions.Bid;
using Auction.Business.Exceptions.Common;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Repositories.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.Services.Implements;

public class BidService : IBidService
{
    readonly IBidRepository _repo;
    readonly IItemRepository _itemRepo;
    readonly IMapper _mapper;
    readonly IHttpContextAccessor _contextAccessor;
    readonly ITokenService _tokenService;
    readonly string _userId;
    readonly string _token;

    public BidService(IBidRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IItemRepository itemRepo, ITokenService tokenService)
    {
        _repo = repo;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
        _tokenService = tokenService;
        _token = _contextAccessor.HttpContext?.Request.Cookies["token"];
        if (_contextAccessor.HttpContext.User.Claims.Any())
        {
            _userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
        }
        else if (_token != null)
        {
            var validatedJwtToken = _tokenService.ValidateToken(_token);
            _userId = validatedJwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        _itemRepo = itemRepo;
    }

    public async Task CreateAsync(BidCreateDTO dto)
    {
        var data = _mapper.Map<Bid>(dto);
        if (!await _itemRepo.IsExistAsync(r => r.Id == dto.ItemId))
            throw new NotFoundException<Item>();
        var item = await _itemRepo.GetByIdAsync(dto.ItemId, false, includes: "Bids");
        if (item.EndingTime <= DateTime.UtcNow)
            throw new InvalidOperationException("Bidding time for this item is ended");
        if (!item.Bids.Any())
        {
            if (dto.Amount < item.CurrentPrice)
                throw new InvalidBidAmountException();
        } 
        else if (dto.Amount <= item.CurrentPrice)
            throw new InvalidBidAmountException();
        item.CurrentPrice = dto.Amount;
        await _itemRepo.SaveAsync();
        data.BidderId = _userId;
        await _repo.CreateAsync(data);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _checkId(id);
        _repo.Delete(data);
        await _repo.SaveAsync();
    }

    public IEnumerable<BidListDTO> GetAll()
        => _mapper.Map<IEnumerable<BidListDTO>>(_repo.GetAll(includes: new[] { "Bidder", "Item" }));

    public async Task<BidDetailsDTO> GetByIdAsync(int id)
    {
        var data = await _checkId(id, true);
        return _mapper.Map<BidDetailsDTO>(data);
    }

    public async Task UpdateAsync(int id, BidUpdateDTO dto)
    {
        var data = await _checkId(id);
        data = _mapper.Map(dto, data);
        await _repo.SaveAsync();
    }

    public async Task SoftDelete(int id)
    {
        var data = await _checkId(id);
        data.IsDeleted = true;
        await _repo.SaveAsync();
    }

    public async Task ReverseSoftDelete(int id)
    {
        var data = await _checkId(id);
        data.IsDeleted = false;
        await _repo.SaveAsync();
    }

    async Task<Bid> _checkId(int id, bool isTrack = false)
    {
        if (id <= 0) throw new ArgumentException();
        var data = await _repo.GetByIdAsync(id, isTrack, "Bidder", "Item");
        if (data == null) throw new NotFoundException<Bid>();
        return data;
    }
}
