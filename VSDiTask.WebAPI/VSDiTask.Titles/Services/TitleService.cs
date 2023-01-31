using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Roles.Models;
using VSDiTask.Titles.Models;
using VSDiTask.Users.Data;

namespace VSDiTask.Roles.Services
{
    public interface ITitleService
    {
        Task<List<GetTitle.Response>> GetTitlesAsync();
        Task<CreateTitle.Response> CreateTitlesAsync(CreateTitle.RequestTitle request);
        Task<CreateTitle.Response> UpdateTitlesAsync(CreateTitle.RequestTitle request);
        Task<CreateTitle.Response> DeleteTitlesAsync(CreateTitle.RequestTitle request);
    }
    public class TitleService : ITitleService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public TitleService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<CreateTitle.Response> CreateTitlesAsync(CreateTitle.RequestTitle request)
        {
            request.MustNotBeNull();
            request.TitleId.MustNotBeNullOrWhiteSpace();
            request.TitleName.MustNotBeNullOrEmpty();

            CreateTitle.Response FailedResult(StatusCode statuscode)
            {
                return new CreateTitle.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsTitleExist(context, request.TitleId))
            {
                return FailedResult(StatusCode.Company_already_exist);
            }

            var entity = context.Titles.Add(new Core.Entities.Title
            {
                TitleId = request.TitleId,
                TitleName = request.TitleName,
                Description = request.Description
            }).Entity;

            await context.SaveChangesAsync();
            return new CreateTitle.Response(true);
        }

        public async Task<CreateTitle.Response> DeleteTitlesAsync(CreateTitle.RequestTitle request)
        {
            request.TitleId.MustNotBeNullOrWhiteSpace();

            CreateTitle.Response FailedResult(StatusCode statuscode)
            {
                return new CreateTitle.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var title = await context.Titles.Where(x => x.TitleId == request.TitleId).FirstOrDefaultAsync();
            if (title == null)
                return FailedResult(StatusCode.Role_not_exist);

            title.deleted = true;
            context.Titles.Update(title);

            await context.SaveChangesAsync();
            return new CreateTitle.Response(true);
        }

        public async Task<List<GetTitle.Response>> GetTitlesAsync()
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Titles
                .Select(x => new GetTitle.Response
                {
                    TitleId = x.TitleId,
                    TitleName = x.TitleName,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<CreateTitle.Response> UpdateTitlesAsync(CreateTitle.RequestTitle request)
        {
            request.MustNotBeNull();
            request.TitleId.MustNotBeNullOrWhiteSpace();
            request.TitleName.MustNotBeNullOrEmpty();

            CreateTitle.Response FailedResult(StatusCode statuscode)
            {
                return new CreateTitle.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var title = await context.Titles.Where(x => x.TitleId == request.TitleId && x.deleted == false).FirstOrDefaultAsync();
            if (title == null)
                return FailedResult(StatusCode.Role_not_exist);

            title.TitleName = request.TitleName;
            title.Description = request.Description;

            var entity = context.Titles.Update(title).Entity;

            await context.SaveChangesAsync();
            return new CreateTitle.Response(true);
        }

        private Task<bool> IsTitleExist(VSDiTaskDBContext context, string code)
        {
            return context.Titles.Where(x => x.TitleId == code)
                .AnyAsync();
        }
    }
}
