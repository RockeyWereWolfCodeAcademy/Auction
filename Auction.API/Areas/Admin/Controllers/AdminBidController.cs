using Auction.Business.DTOs.BidDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Services.Implements;
using Auction.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBidController : AdminControllerBase
{
    readonly IBidService _service;
    readonly IItemService _itemService;

    public AdminBidController(IBidService service, ITokenService tokenService, IItemService itemService) : base(tokenService)
    {
        _service = service;
        _itemService = itemService;
    }

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }

    public IActionResult Create()
    {
        ViewBag.Items = _itemService.GetAll();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(BidCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Items = _itemService.GetAll();
            return View();
        }
        await _service.CreateAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(int id)
    {
        var data = await _service.GetByIdAsync(id);
        ViewBag.Items = _itemService.GetAll();
        return View(new BidUpdateDTO
        {
            ItemId = data.ItemId,
            Amount = data.Amount,
        });
    }
    [HttpPost]
    public async Task<IActionResult> Update(int id, BidUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Items = _itemService.GetAll();
            return View();
        }
        await _service.UpdateAsync(id, dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
