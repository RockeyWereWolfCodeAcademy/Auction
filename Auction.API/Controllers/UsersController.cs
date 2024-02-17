using Auction.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll() 
        {
            return Ok(_userService.GetAllUsers()); 
        }

        [HttpGet]
        [Route("GetActivity")]
        public IActionResult GetUserActivityLog(string userId) 
        {
            return Ok(_userService.GetActivityLogByUserId(userId)); 
        }
    }
}
