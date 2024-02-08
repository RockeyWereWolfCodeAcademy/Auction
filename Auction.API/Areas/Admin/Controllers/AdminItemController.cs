using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.ExternalServices.Implements;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auction.API.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminItemController : AdminControllerBase
{
    readonly IItemService _service;
    readonly ICategoryService _categoryService;
    public AdminItemController(IItemService service, ITokenService tokenService, ICategoryService categoryService) : base(tokenService)
    {
        _service = service;
        _categoryService = categoryService;
    }
    public IActionResult Index()
    {
        return View(_service.GetAll());
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _categoryService.GetAll();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(ItemCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        await _service.CreateAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(int id)
    {
        ViewBag.Categories = _categoryService.GetAll();
        var data = await _service.GetByIdAsync(id);
        return View(new ItemUpdateDTO
        {
            Name = data.Name,
            Description = data.Description,
            StartingPrice = data.StartingPrice,
            StartingTime = data.StartingTime,
            EndingTime = data.EndingTime,
            CategoryId = data.CategoryId,
        });
    }
    [HttpPost]
    public async Task<IActionResult> Update(int id, ItemUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _categoryService.GetAll();
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
