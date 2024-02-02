using Auction.Business.DTOs.AuthDTOs;
using Auction.Business.ExternalServices.Interfaces;
using Auction.Business.Services.Interfaces;
using Auction.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Auction.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    readonly IEmailService _emailService;
    readonly IMapper _mapper;
    readonly IUserService _userService;
    readonly IAuthService _authService;


    public AuthController(IEmailService emailService, IMapper mapper, IUserService userService, IAuthService authService)
    {
        _emailService = emailService;
        _mapper = mapper;
        _userService = userService;
        _authService = authService;
    }
    [HttpGet]
    [Route("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        var result = await _authService.ConfirmEmail(token, email);
        var response = result == true ? nameof(ConfirmEmail) : "Unexpected error";
        return new BadRequestObjectResult(response);
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        await _userService.CreateAsync(dto);

        _emailService.SendEmail(dto.Email, "Welcome", $"<h1>Welcome to our system {dto.UserName}!</h1>" +
            $"<p>Now you need to confirm your account {await GenerateConfirmationLink(dto)} </p>");
        return Ok(new { Message = "User Reigstration Successful, please check your email for confirmation link!" });
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        return Ok(await _authService.Login(dto));
    }

    private async Task<string> GenerateConfirmationLink(RegisterDTO dto)
    {
        var user = _mapper.Map<AppUser>(dto);
        var token = await _authService.GetConfirmationToken(user);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "Auth", new { token, email = user.Email }, Request.Scheme);
        return confirmationLink;
    }
}
