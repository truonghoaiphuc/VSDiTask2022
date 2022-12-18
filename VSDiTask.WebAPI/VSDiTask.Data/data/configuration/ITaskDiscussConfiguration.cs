using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class ITaskDiscussConfiguration : IEntityTypeConfiguration<ITaskDiscuss>
    {
        public void Configure(EntityTypeBuilder<ITaskDiscuss> builder)
        {
            builder.ToTable("ITaskDiscusses");

            builder.Property(x => x.STaskId)
                .IsRequired();
            builder.Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.deleted).HasDefaultValue(false);
        }
    }
}
