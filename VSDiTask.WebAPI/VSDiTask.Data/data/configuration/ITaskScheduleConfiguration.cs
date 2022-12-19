using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class ITaskScheduleConfiguration : IEntityTypeConfiguration<ITaskSchedule>
    {
        public void Configure(EntityTypeBuilder<ITaskSchedule> builder)
        {
            builder.ToTable("ITaskSchedules");

            builder.Property(x => x.ITaskId)
                .IsRequired();
            builder.Property(x => x.UserId)
                .IsRequired();
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.deleted).HasDefaultValue(false);
        }
    }
}
