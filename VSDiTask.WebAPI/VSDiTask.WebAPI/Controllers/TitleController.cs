using Microsoft.AspNetCore.Mvc;
using VSDiTask.Roles.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ApplicationBaseController
    {
        private readonly ITitleService _titleService;
        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet]
        public async Task<IActionResult> Titles()
        {
            var result = await _titleService.GetTitlesAsync();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateTitle(VSDiTask.Titles.Models.CreateTitle.RequestTitle request)
        {
            var role = await _titleService.UpdateTitlesAsync(request);
            return Ok(role);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTitle(VSDiTask.Titles.Models.CreateTitle.RequestTitle request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var role = await _titleService.CreateTitlesAsync(request);
            return Ok(role);
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete(VSDiTask.Titles.Models.CreateTitle.RequestTitle request)
        {
            var role = await _titleService.DeleteTitlesAsync(request);
            return Ok(role);
        }
    }
}
