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
        try
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("Create")]
    [Authorize]
    public async Task<IActionResult> Create(BidCreateDTO dto)
    {
        try
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpDelete("Delete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch("SoftDelete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _service.SoftDelete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPatch("ReverseSoftDelete/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> ReverseSoftDelete(int id)
    {
        try
        {
            await _service.ReverseSoftDelete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("Update/{id}")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public async Task<IActionResult> Update(int id, BidUpdateDTO dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
