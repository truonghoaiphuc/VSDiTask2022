using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(x => x.UserName)
                .IsUnique();
            builder.Property(x => x.LastName).HasMaxLength(250);
            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Avatar).HasMaxLength(250);
        }
    }
}
