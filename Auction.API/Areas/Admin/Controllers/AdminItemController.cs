using Auction.API.Areas.Admin.Controllers.Common;
using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.ExternalServices.Implements;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;

namespace Auction.API.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminItemController : AdminControllerBase
{
    readonly IItemService _service;
    readonly ICategoryService _categoryService;
    readonly IMapper _mapper;
    public AdminItemController(IItemService service, ITokenService tokenService, ICategoryService categoryService, IMapper mapper) : base(tokenService)
    {
        _service = service;
        _categoryService = categoryService;
        _mapper = mapper;
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
        return View(_mapper.Map(data, new ItemUpdateDTO()));
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

    public async Task<IActionResult> SoftDeleteAsync(int id)
    {
        await _service.SoftDelete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ReverseSoftDeleteAsync(int id)
    {
        await _service.ReverseSoftDelete(id);
        return RedirectToAction("Index");
    }
}
