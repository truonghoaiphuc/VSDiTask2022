using Microsoft.AspNetCore.Mvc;
using VSDiTask.Services.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ApplicationBaseController
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Companies()
        {
            var companies = await _companyService.GetListCompanyAsync(new VSDiTask.Services.Models.GetListCompany.Request { });
            return Ok(companies);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllCompanyAsync(new VSDiTask.Services.Models.GetListCompany.Request { });
            return Ok(companies);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(VSDiTask.Services.Models.AddCompany.Request request)
        {
            var comp = await _companyService.UpdateCompanyAsync(request);
            return Ok(comp);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(VSDiTask.Services.Models.AddCompany.Request request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var comp = await _companyService.AddCompanyAsync(request);
            return Ok(comp);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string code)
        {
            var comp = await _companyService.DeleteCompanyAsync(new VSDiTask.Services.Models.AddCompany.Request { CompCode = code });
            return Ok(comp);
        }
    }
}
