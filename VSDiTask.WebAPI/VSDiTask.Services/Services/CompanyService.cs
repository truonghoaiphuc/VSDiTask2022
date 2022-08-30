using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Services.Models;
using VSDiTask.Users.Data;

namespace VSDiTask.Services.Services
{
    public interface ICompanyService
    {
        Task<AddCompany.Response> AddProductAsync(AddCompany.Request company);
    }
    public class CompanyService : ICompanyService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public CompanyService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<AddCompany.Response> AddProductAsync(AddCompany.Request company)
        {
            company.MustNotBeNull();
            company.CompanyCode.MustNotBeNullOrWhiteSpace();
            company.CompanyName.MustNotBeNullOrEmpty();

            AddCompany.Response FailedResult(StatusCode statuscode)
            {
                return new AddCompany.Response
                {
                    StatusCode = statuscode,
                };
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsCompanyExist(context, company.CompanyCode))
            {
                return FailedResult(StatusCode.Company_already_exist);
            }

            var entity = context.Companies.Add(new Core.Entities.Company
            {
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            }).Entity;

            await context.SaveChangesAsync();
            return new AddCompany.Response
            {
                Id = entity.Id,
            };
        }

        private Task<bool> IsCompanyExist(VSDiTaskDBContext context, string code)
        {
            return context.Companies.Where(x => x.CompanyCode == code)
                .AnyAsync();
        }
    }
}
