using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class ListOffDateConfiguration : IEntityTypeConfiguration<ListOffDate>
    {
        public void Configure(EntityTypeBuilder<ListOffDate> builder)
        {
            builder.ToTable("ListOffDates");

            builder.Property(x => x.OffDate)
                .IsRequired();
        }
    }
}
