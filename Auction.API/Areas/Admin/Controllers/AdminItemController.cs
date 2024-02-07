using Auction.Business.DTOs.AuthDTOs;
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
    public AdminItemController(IItemService service, ITokenService tokenService) : base(tokenService)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        return View(_service.GetAll());
    }
}
