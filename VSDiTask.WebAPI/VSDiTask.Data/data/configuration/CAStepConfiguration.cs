using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSDiTask.Core.Entities;

namespace VSDiTask.Infrastructure.data.configuration
{
    public class CAStepConfiguration : IEntityTypeConfiguration<CAStep>
    {
        public void Configure(EntityTypeBuilder<CAStep> builder)
        {
            builder.ToTable("CASteps");

            builder.Property(x => x.CATypeId)
                .IsRequired();
            builder.Property(x => x.StepName)
                .IsRequired();
            builder.Property(x => x.StepOrder)
                .IsRequired();
            builder.Property(x => x.Duration)
                .IsRequired();
        }
    }
}
