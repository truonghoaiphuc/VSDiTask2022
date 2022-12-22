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
    }
}
