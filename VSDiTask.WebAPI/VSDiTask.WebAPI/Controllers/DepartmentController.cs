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
            var depts = await _departmentService.GetListDepartmentAsync(new VSDiTask.Services.Models.GetListDepartment.Request { });
            return Ok(depts);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateDepartment(VSDiTask.Services.Models.AddDepartment.RequestDept dept)
        {
            var depts = await _departmentService.UpdateDepartmentAsync(dept);
            return Ok(depts);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(VSDiTask.Services.Models.AddDepartment.RequestDept request)
        {
            var comp = await _departmentService.AddDepartmentAsync(request);
            return Ok(comp);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string deptCode)
        {
            var comp = await _departmentService.DeleteDepartmentAsync(new VSDiTask.Services.Models.AddDepartment.RequestDept { DeptCode = deptCode });
            return Ok(comp);
        }
    }
}
