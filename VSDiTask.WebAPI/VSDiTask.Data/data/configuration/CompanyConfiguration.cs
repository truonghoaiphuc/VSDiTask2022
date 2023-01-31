using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.Property(x => x.CompName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.CompCode)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(x => x.CompCode)
                .IsUnique();
            builder.Property(x => x.deleted).HasDefaultValue<bool>(false);
        }
    }
}
