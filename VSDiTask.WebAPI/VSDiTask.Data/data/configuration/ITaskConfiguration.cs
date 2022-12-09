using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class ITaskConfiguration : IEntityTypeConfiguration<ITask>
    {
        public void Configure(EntityTypeBuilder<ITask> builder)
        {
            builder.ToTable("ITasks");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
