using Microsoft.AspNetCore.Mvc;
using VSDiTask.Roles.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CATypeController : ApplicationBaseController
    {
        private readonly ICATypeService _caTypeService;
        public CATypeController(ICATypeService caTypeService)
        {
            _caTypeService = caTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> CATypes()
        {
            var result = await _caTypeService.GetCATypesAsync();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCAType(VSDiTask.CATypes.Models.CreateCAType.RequestCAType request)
        {
            var role = await _caTypeService.UpdateCATypeAsync(request);
            return Ok(role);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCAType(VSDiTask.CATypes.Models.CreateCAType.RequestCAType request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var role = await _caTypeService.CreateCATypeAsync(request);
            return Ok(role);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(VSDiTask.CATypes.Models.CreateCAType.RequestCAType request)
        {
            var role = await _caTypeService.DeleteCATypeAsync(request);
            return Ok(role);
        }
    }
}
