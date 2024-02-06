using Auction.Business.DTOs.BidDTOs;
using Auction.Business.DTOs.ItemDTOs;
using Auction.Business.Services.Interfaces;
using Auction.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BidsController : ControllerBase
{
    readonly IBidService _service;
    public BidsController(IBidService service)
    {
        _service = service;
    }
    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }
    [HttpGet("Get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }
    [HttpPost]
    [Route("Create")]
    [Authorize]
    public async Task<IActionResult> Create(BidCreateDTO dto)
    {
        await _service.CreateAsync(dto);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete("Delete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
    [HttpPatch("SoftDelete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _service.SoftDelete(id);
        return Ok();
    }
    [HttpPatch("ReverseSoftDelete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> ReverseSoftDelete(int id)
    {
        await _service.ReverseSoftDelete(id);
        return Ok();
    }
    [HttpPut("Update/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> Update(int id, BidUpdateDTO dto)
    {
        await _service.UpdateAsync(id, dto);
        return Ok();
    }
}
