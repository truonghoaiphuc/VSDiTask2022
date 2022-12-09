using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable("Functions");

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}
