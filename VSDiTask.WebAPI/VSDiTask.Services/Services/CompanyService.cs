using VSDiTask.Infrastructure;

namespace VSDiTask.Services.Services
{
    public interface ICompanyService
    {

    }
    public class CompanyService : ICompanyService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public CompanyService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }
    }
}
