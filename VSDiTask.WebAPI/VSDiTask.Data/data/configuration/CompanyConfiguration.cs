using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Product", "products");

            builder.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.CompanyCode)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasIndex(x => x.CompanyCode)
                .IsUnique();
        }
    }
}
