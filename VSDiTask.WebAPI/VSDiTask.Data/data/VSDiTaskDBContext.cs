using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Entities;
using VSDiTask.Infrastructure.data.configuration;

namespace VSDiTask.Infrastructure
{
    public class VSDiTaskDBContext : DbContext
    {
        public VSDiTaskDBContext(DbContextOptions<VSDiTaskDBContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=PHUCTH\\SQLSERVER2012;Database=VSDiTasks2022;User Id=sa;Password=backinh27;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
