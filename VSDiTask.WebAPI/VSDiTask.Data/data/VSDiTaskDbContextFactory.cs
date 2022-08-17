using Microsoft.EntityFrameworkCore;

namespace VSDiTask.Core.Data
{
    public interface IVSDiTaskDbContextFactory : IDbContextFactory<VSDiTaskDBContext>
    {

    }
    public class VSDiTaskDbContextFactory : IVSDiTaskDbContextFactory
    {
        private readonly DbContextOptions<VSDiTaskDBContext> _options;
        public VSDiTaskDbContextFactory(DbContextOptions<VSDiTaskDBContext> options)
        {
            _options = options;
        }

        public VSDiTaskDBContext CreateDbContext()
        {
            var db = new VSDiTaskDBContext(_options);

            //todo: config db            

            return db;
        }
    }
}
