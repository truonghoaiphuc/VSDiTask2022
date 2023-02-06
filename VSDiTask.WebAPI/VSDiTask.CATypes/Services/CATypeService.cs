using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.CATypes.Models;
using VSDiTask.Core.Data;
using VSDiTask.Users.Data;

namespace VSDiTask.Roles.Services
{
    public interface ICATypeService
    {
        Task<List<GetCAType.Response>> GetCATypesAsync();
        Task<CreateCAType.Response> CreateCATypeAsync(CreateCAType.RequestCAType request);
        Task<CreateCAType.Response> UpdateCATypeAsync(CreateCAType.RequestCAType request);
        Task<CreateCAType.Response> DeleteCATypeAsync(CreateCAType.RequestCAType request);
    }
    public class CATypeService : ICATypeService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public CATypeService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<CreateCAType.Response> CreateCATypeAsync(CreateCAType.RequestCAType request)
        {
            request.MustNotBeNull();
            request.CAName.MustNotBeNullOrEmpty();

            CreateCAType.Response FailedResult(StatusCode statuscode)
            {
                return new CreateCAType.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsCATypeExist(context, request.CAName))
            {
                return FailedResult(StatusCode.CAType_already_exist);
            }

            var entity = context.CATypes.Add(new Core.Entities.CAType
            {
                CAName = request.CAName,
                Description = request.Description
            }).Entity;

            await context.SaveChangesAsync();
            return new CreateCAType.Response(true);
        }

        public async Task<CreateCAType.Response> DeleteCATypeAsync(CreateCAType.RequestCAType request)
        {
            CreateCAType.Response FailedResult(StatusCode statuscode)
            {
                return new CreateCAType.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var catype = await context.CATypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (catype == null)
                return FailedResult(StatusCode.CAType_not_exist);

            context.CATypes.Remove(catype);

            await context.SaveChangesAsync();
            return new CreateCAType.Response(true);
        }

        public async Task<List<GetCAType.Response>> GetCATypesAsync()
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.CATypes
                .Select(x => new GetCAType.Response
                {
                    Id = x.Id,
                    CAName = x.CAName,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<CreateCAType.Response> UpdateCATypeAsync(CreateCAType.RequestCAType request)
        {
            request.MustNotBeNull();
            request.CAName.MustNotBeNullOrEmpty();

            CreateCAType.Response FailedResult(StatusCode statuscode)
            {
                return new CreateCAType.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var catype = await context.CATypes.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (catype == null)
                return FailedResult(StatusCode.Role_not_exist);

            catype.CAName = request.CAName;
            catype.Description = request.Description;

            var entity = context.CATypes.Update(catype).Entity;

            await context.SaveChangesAsync();
            return new CreateCAType.Response(true);
        }

        private Task<bool> IsCATypeExist(VSDiTaskDBContext context, string code)
        {
            return context.CATypes.Where(x => x.CAName == code)
                .AnyAsync();
        }
    }
}
