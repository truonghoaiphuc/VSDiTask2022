using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Roles.Models;

namespace VSDiTask.Roles.Services
{
    public interface ITitleService
    {
        Task<List<GetTitle.Response>> GetTitlesAsync();
    }
    public class TitleService : ITitleService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public TitleService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

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
    }
}
