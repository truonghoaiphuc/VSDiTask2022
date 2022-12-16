using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Services.Models;
using VSDiTask.Users.Data;

namespace VSDiTask.Services.Services
{
    public interface IDepartmentService
    {
        Task<AddDepartment.Response> AddDepartmentAsync(AddDepartment.Request dept);
        Task<AddDepartment.Response> UpdateDepartmentAsync(AddDepartment.Request dept);
        Task<AddDepartment.Response> DeleteDepartmentAsync(AddDepartment.Request dept);
        Task<List<GetListDepartment.Response>> GetListDepartmentAsync(GetListDepartment.Request request);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public DepartmentService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<AddDepartment.Response> AddDepartmentAsync(AddDepartment.Request dept)
        {
            dept.MustNotBeNull();
            dept.DeptCode.MustNotBeNullOrWhiteSpace();
            dept.DeptName.MustNotBeNullOrEmpty();
            dept.Branch.MustNotBeNullOrEmpty();

            AddDepartment.Response FailedResult(StatusCode statuscode)
            {
                return new AddDepartment.Response
                {
                    StatusCode = statuscode,
                };
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsDepartmentExist(context, dept.DeptCode))
            {
                return FailedResult(StatusCode.Department_already_exist);
            }

            var entity = context.Departments.Add(new Core.Entities.Department
            {
                DeptCode = dept.DeptCode,
                DeptName = dept.DeptName,
                Branch = dept.Branch
            }).Entity;

            await context.SaveChangesAsync();
            return new AddDepartment.Response
            {
                Id = entity.DeptCode,
            };
        }

        public async Task<AddDepartment.Response> DeleteDepartmentAsync(AddDepartment.Request dept)
        {
            dept.MustNotBeNull();
            dept.DeptCode.MustNotBeNullOrWhiteSpace();

            AddDepartment.Response FailedResult(StatusCode statuscode)
            {
                return new AddDepartment.Response
                {
                    StatusCode = statuscode,
                };
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var dep = await context.Departments.Where(x => x.DeptCode == dept.DeptCode).FirstOrDefaultAsync();
            if (dep == null)
                return FailedResult(StatusCode.Department_not_exist);

            var entity = context.Departments.Remove(dep).Entity;

            await context.SaveChangesAsync();
            return new AddDepartment.Response
            {
                Id = entity.DeptCode,
            };
        }

        public async Task<List<GetListDepartment.Response>> GetListDepartmentAsync(GetListDepartment.Request request)
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Departments
                .Select(x => new GetListDepartment.Response
                {
                    deptCode = x.DeptCode,
                    deptName = x.DeptName,
                    branch = x.Branch
                })
                .ToListAsync();
        }

        public async Task<AddDepartment.Response> UpdateDepartmentAsync(AddDepartment.Request dept)
        {
            dept.MustNotBeNull();
            dept.DeptCode.MustNotBeNullOrWhiteSpace();
            dept.DeptName.MustNotBeNullOrEmpty();
            dept.Branch.MustNotBeNullOrEmpty();

            AddDepartment.Response FailedResult(StatusCode statuscode)
            {
                return new AddDepartment.Response
                {
                    StatusCode = statuscode,
                };
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var dep = await context.Departments.Where(x => x.DeptCode == dept.DeptCode).FirstOrDefaultAsync();
            if (dep == null)
                return FailedResult(StatusCode.Department_not_exist);

            dep.DeptName = dept.DeptName;
            dep.Branch = dept.Branch;

            var entity = context.Departments.Update(dep).Entity;

            await context.SaveChangesAsync();
            return new AddDepartment.Response
            {
                Id = entity.DeptCode,
            };
        }

        private Task<bool> IsDepartmentExist(VSDiTaskDBContext context, string code)
        {
            return context.Departments.Where(x => x.DeptCode == code)
                .AnyAsync();
        }
    }
}
