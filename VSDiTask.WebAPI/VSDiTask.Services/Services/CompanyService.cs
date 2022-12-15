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
        Task<List<GetListCompany.Response>> GetListCompanyAsync(GetListCompany.Request request);
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
                return new AddCompany.Response
                {
                    StatusCode = statuscode,
                };
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
            return new AddCompany.Response
            {
                Id = entity.CompCode,
            };
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
        private Task<bool> IsCompanyExist(VSDiTaskDBContext context, string code)
        {
            return context.Companies.Where(x => x.CompCode == code)
                .AnyAsync();
        }
    }
}
