using Auction.Business.DTOs.CategoryDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Services.Implements;
using Auction.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCategoryController : AdminControllerBase
{
    readonly ICategoryService _service;

    public AdminCategoryController(ICategoryService service, ITokenService tokenService) : base(tokenService)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.GetAll());
    }

    public IActionResult Create()
    {
        ViewBag.Categories = _service.GetAll();
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _service.GetAll();
            return View();
        }
        await _service.CreateAsync(dto);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(int id)
    {
        var data = await _service.GetByIdAsync(id);
        ViewBag.Categories = _service.GetAll();
        return View(new CategoryUpdateDTO
        {
            Name = data.Name,
            ParentCategoryId = data.ParentCategoryId,
        });
    }
    [HttpPost]
    public async Task<IActionResult> Update(int id, CategoryUpdateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _service.GetAll();
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
