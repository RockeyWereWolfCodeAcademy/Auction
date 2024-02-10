using Auction.Business.ExternalServices.Interfaces;
using Auction.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Auction.API.Areas.Admin.Controllers.Common
{
    public class AdminControllerBase : Controller
    {
        readonly ITokenService _tokenService;

        public AdminControllerBase(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var token = HttpContext.Request.Cookies["token"];
            if (token == null)
            {
                context.Result = RedirectToAction("Login", "AdminAuth");
                return;
            }
            var validatedJwtToken = _tokenService.ValidateToken(token);

            var role = validatedJwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == null || !role.Equals(nameof(Roles.Admin)))
            {
                context.Result = RedirectToAction("Login", "AdminAuth");
                return;
            }
            base.OnActionExecuted(context);
        }
    }
}
