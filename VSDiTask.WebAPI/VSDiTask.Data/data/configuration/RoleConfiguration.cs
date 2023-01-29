using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.Property(x => x.RoleId)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.RoleName)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(x => x.RoleId)
                .IsUnique();
            builder.Property(x => x.deleted).HasDefaultValue<bool>(false);
        }
    }
}
