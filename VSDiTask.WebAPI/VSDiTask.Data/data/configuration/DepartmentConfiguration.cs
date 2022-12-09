using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.Property(x => x.DeptName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.DeptCode)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(x => x.DeptCode)
                .IsUnique();
            builder.Property(x => x.Branch)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
