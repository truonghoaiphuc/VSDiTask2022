using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUser");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(x => x.UserName)
                .IsUnique();
            builder.Property(x => x.FirstName).HasMaxLength(250);
            builder.Property(x => x.LastName).HasMaxLength(250);
            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.deleted).HasDefaultValue<bool>(false);
        }
    }
}
