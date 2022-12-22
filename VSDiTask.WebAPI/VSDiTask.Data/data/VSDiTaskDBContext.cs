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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ITask> ITasks { get; set; }
        public DbSet<ITaskSchedule> ITaskSchedules { get; set; }
        public DbSet<ITaskDiscuss> ITaskDiscusses { get; set; }
        public DbSet<ListOffDate> ListOffDates { get; set; }
        public DbSet<CAType> CATypes { get; set; }
        public DbSet<CAStep> CASteps { get; set; }
        public DbSet<User> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new FunctionConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new ITaskConfiguration());
            modelBuilder.ApplyConfiguration(new ITaskScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new ITaskDiscussConfiguration());
            modelBuilder.ApplyConfiguration(new ListOffDateConfiguration());
            modelBuilder.ApplyConfiguration(new CATypeConfiguration());
            modelBuilder.ApplyConfiguration(new CAStepConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
