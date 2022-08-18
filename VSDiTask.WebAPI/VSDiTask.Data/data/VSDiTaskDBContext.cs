using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Entities;
using VSDiTask.Infrastructure.data.configuration;

namespace VSDiTask.Core.Data
{
    public class VSDiTaskDBContext : DbContext
    {
        public VSDiTaskDBContext(DbContextOptions<VSDiTaskDBContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
