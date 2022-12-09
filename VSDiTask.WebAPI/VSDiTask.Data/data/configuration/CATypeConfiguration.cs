using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class CATypeConfiguration : IEntityTypeConfiguration<CAType>
    {
        public void Configure(EntityTypeBuilder<CAType> builder)
        {
            builder.ToTable("CATypes");

            builder.Property(x => x.CAName)
                .IsRequired();
        }
    }
}
