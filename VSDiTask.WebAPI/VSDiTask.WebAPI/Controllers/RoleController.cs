using Microsoft.AspNetCore.Mvc;
using VSDiTask.Roles.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApplicationBaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRolePermissionBy(string roleId)
        {
            var permissions = await _roleService.GetRolePermissionBy(new VSDiTask.Roles.Models.GetRole.RequestRole { RoleId = roleId });
            return Ok(permissions);
        }

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            var permissions = await _roleService.GetRolesAsync();
            return Ok(permissions);
        }

        //[HttpGet("all")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var companies = await _companyService.GetAllCompanyAsync(new VSDiTask.Services.Models.GetListCompany.Request { });
        //    return Ok(companies);
        //}

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRole(VSDiTask.Roles.Models.CreateRole.RequestRole request)
        {
            var role = await _roleService.UpdateRoleAsync(request);
            return Ok(role);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(VSDiTask.Roles.Models.CreateRole.RequestRole request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var role = await _roleService.CreateRoleAsync(request);
            return Ok(role);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string code)
        {
            var role = await _roleService.DeleteRoleAsync(code);
            return Ok(role);
        }
    }
}
