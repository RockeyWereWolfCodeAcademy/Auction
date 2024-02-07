using Auction.Business.DTOs.AuthDTOs;
using Auction.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text;

namespace Auction.API.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminAuthController : Controller
{
    readonly IHttpContextFactory _contextFactory;

    public AdminAuthController(IHttpContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(string? returnUrl, LoginDTO dto)
    {
        using var client = new HttpClient();
        
        var parameters = new Dictionary<string, string> {
            { "UsernameOrEmail", dto.UsernameOrEmail },
            { "Password", dto.Password }
        };

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://localhost:7229/api/Auth/Login", data);
        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "Username or password is wrong");
            return View(dto);
        }
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }
        var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDTO>(await response.Content.ReadAsStringAsync());
        var option = new CookieOptions();
        option.Expires = result.ValidUntil;
        HttpContext.Response.Cookies.Append("token", result.Token, option);
        return RedirectToAction("Index", "AdminItem");
    }
}
