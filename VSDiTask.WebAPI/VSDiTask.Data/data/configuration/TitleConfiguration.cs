using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Titles");

            builder.Property(x => x.TitleId)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.TitleName)
                .IsRequired()
                .HasMaxLength(250);
            builder.HasIndex(x => x.TitleId)
                .IsUnique();
        }
    }
}
