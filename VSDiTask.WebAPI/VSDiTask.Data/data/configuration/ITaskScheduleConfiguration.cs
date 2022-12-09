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

            builder.Property(x => x.TaskId)
                .IsRequired();
            builder.Property(x => x.UserId)
                .IsRequired();
        }
    }
}
