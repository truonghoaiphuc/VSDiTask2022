using Microsoft.AspNetCore.Mvc;
using VSDiTask.Services.Services;

namespace VSDiTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/dept")]
    public class DepartmentController : ApplicationBaseController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Departments()
        {
            var companies = await _departmentService.GetListDepartmentAsync(new VSDiTask.Services.Models.GetListDepartment.Request { });
            return Ok(companies);
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateDepartment(VSDiTask.Services.Models.AddDepartment.Request dept)
        //{
        //    return Ok(true);
        //}

        //[HttpPost("add")]
        //public async Task<IActionResult> Add(VSDiTask.Services.Models.AddDepartment.Request request)
        //{
        //    var comp = await _departmentService.AddDepartmentAsync(request);
        //    return Ok(comp);
        //}

        //[HttpDelete("delete")]
        //public async Task<IActionResult> Delete(VSDiTask.Services.Models.AddDepartment.Request request)
        //{
        //    var comp = await _departmentService.DeleteDepartmentAsync(request);
        //    return Ok(comp);
        //}
    }
}
