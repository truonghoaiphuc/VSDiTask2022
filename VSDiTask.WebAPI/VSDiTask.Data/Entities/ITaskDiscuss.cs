using System.ComponentModel.DataAnnotations.Schema;

namespace VSDiTask.Core.Entities
{
    public class ITaskDiscuss : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        [ForeignKey("ITaskSchedule")]
        public long STaskId { get; set; }
        public ITaskSchedule ITaskSchedule { get; set; }
        public string Content { get; set; }
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
