using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Services.Models;
using VSDiTask.Users.Data;

namespace VSDiTask.Services.Services
{
    public interface ICompanyService
    {
        Task<AddCompany.Response> AddCompanyAsync(AddCompany.Request company);
        Task<AddCompany.Response> UpdateCompanyAsync(AddCompany.Request company);
        Task<AddCompany.Response> DeleteCompanyAsync(AddCompany.Request company);
        Task<List<GetListCompany.Response>> GetListCompanyAsync(GetListCompany.Request request);
        Task<List<GetListCompany.Response>> GetAllCompanyAsync(GetListCompany.Request request);
    }
    public class CompanyService : ICompanyService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public CompanyService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<AddCompany.Response> AddCompanyAsync(AddCompany.Request company)
        {
            company.MustNotBeNull();
            company.CompCode.MustNotBeNullOrWhiteSpace();
            company.CompName.MustNotBeNullOrEmpty();

            AddCompany.Response FailedResult(StatusCode statuscode)
            {
                return new AddCompany.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsCompanyExist(context, company.CompCode))
            {
                return FailedResult(StatusCode.Company_already_exist);
            }

            var entity = context.Companies.Add(new Core.Entities.Company
            {
                CompCode = company.CompCode,
                CompName = company.CompName,
                CompAddress = company.CompAddress
            }).Entity;

            await context.SaveChangesAsync();
            return new AddCompany.Response(true);
        }

        public async Task<AddCompany.Response> DeleteCompanyAsync(AddCompany.Request company)
        {
            company.MustNotBeNull();
            company.CompCode.MustNotBeNullOrWhiteSpace();

            AddCompany.Response FailedResult(StatusCode statuscode)
            {
                return new AddCompany.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var comp = await context.Companies.Where(x => x.CompCode == company.CompCode).FirstOrDefaultAsync();
            if (comp == null)
                return FailedResult(StatusCode.Company_not_exist);

            var entity = context.Companies.Remove(comp).Entity;

            await context.SaveChangesAsync();
            return new AddCompany.Response(true);
        }

        public async Task<List<GetListCompany.Response>> GetAllCompanyAsync(GetListCompany.Request request)
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Companies
                .Select(x => new GetListCompany.Response
                {
                    compCode = x.CompCode,
                    compName = x.CompName,
                    compAddress = x.CompAddress,
                    Depts = context.Departments
                        .Where(y => y.Branch == x.CompCode)
                        .Select(c => new GetListDepartment.Response
                        {
                            deptCode = c.DeptCode,
                            deptName = c.DeptName,
                            branch = c.Branch
                        })
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task<List<GetListCompany.Response>> GetListCompanyAsync(GetListCompany.Request request)
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Companies
                .Select(x => new GetListCompany.Response
                {
                    compCode = x.CompCode,
                    compName = x.CompName,
                    compAddress = x.CompAddress
                })
                .ToListAsync();
        }

        public async Task<AddCompany.Response> UpdateCompanyAsync(AddCompany.Request company)
        {
            company.MustNotBeNull();
            company.CompCode.MustNotBeNullOrWhiteSpace();
            company.CompName.MustNotBeNullOrEmpty();

            AddCompany.Response FailedResult(StatusCode statuscode)
            {
                return new AddCompany.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var comp = await context.Companies.Where(x => x.CompCode == company.CompCode).FirstOrDefaultAsync();
            if (comp == null)
                return FailedResult(StatusCode.Company_not_exist);

            comp.CompName = company.CompName;
            comp.CompAddress = company.CompAddress;

            var entity = context.Companies.Update(comp).Entity;

            await context.SaveChangesAsync();
            return new AddCompany.Response(true);
        }

        private Task<bool> IsCompanyExist(VSDiTaskDBContext context, string code)
        {
            return context.Companies.Where(x => x.CompCode == code)
                .AnyAsync();
        }
    }
}
