using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSDiTask.Users.Models;
using VSDiTask.Users.Services;
using VSDiTask.WebAPI.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            var valid = await _userService.IsValidUserAccountAsync(user);

            if (valid)
            {
                var userInfo = await _userService.GetUserInfoAsync(user.UserName);
                var token = _tokenService.GetToken(userInfo, 60);

                return Ok(new
                {
                    token,
                    userInfo
                });
            }
            return BadRequest(new
            {
                StatusCode = "invalid_user_account"
            });
        }
    }
}
