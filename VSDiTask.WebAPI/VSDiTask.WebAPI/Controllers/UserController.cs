using Microsoft.AspNetCore.Mvc;
using VSDiTask.Users.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApplicationBaseController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser(VSDiTask.Users.Models.AddUser.Request request)
        {
            var comp = await _userService.AddUserAsync(request);
            return Ok(comp);
        }
    }
}
