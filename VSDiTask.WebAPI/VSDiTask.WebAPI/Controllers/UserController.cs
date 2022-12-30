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
        public async Task<IActionResult> AddUser(VSDiTask.Users.Models.CreateUser.RequestUser request)
        {
            var comp = await _userService.AddUserAsync(request);
            return Ok(comp);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserDetail(long id)
        {
            var result = await _userService.GetUserDetailAsync(id);
            return Ok(result);
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserPermissionBy(string username)
        {
            var permissions = await _userService.GetUserByAsync(username);
            return Ok(permissions);
        }

        [HttpGet()]
        public async Task<IActionResult> GetListUser()
        {
            var users = await _userService.GetListUserAsync();
            return Ok(users);
        }
    }
}
