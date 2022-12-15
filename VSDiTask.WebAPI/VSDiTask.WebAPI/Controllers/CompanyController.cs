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
        //public IActionResult AddCompany(Company company)
        //{

        //}
        [HttpGet]
        public async Task<IActionResult> Companies()
        {
            var companies = await _companyService.GetListCompanyAsync(new VSDiTask.Services.Models.GetListCompany.Request { });
            return Ok(companies);
        }
    }
}
