using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using VSDiTask.Core.Data;

namespace VSDiTask.WebAPI
{
    public class VSDiTaskDBContextFactory : IDesignTimeDbContextFactory<VSDiTaskDBContext>
    {
        public VSDiTaskDBContext CreateDbContext(string[] arg)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true);
            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("VSDiTaskConnection");

            var dbContextOptionBuilder = new DbContextOptionsBuilder<VSDiTaskDBContext>();
            dbContextOptionBuilder.UseSqlServer(connectionString);

            return new VSDiTaskDBContext(dbContextOptionBuilder.Options);
        }
    }
}
