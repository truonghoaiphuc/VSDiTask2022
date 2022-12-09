namespace VSDiTask.Core.Entities
{
    public class ITaskSchedule : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        public long TaskId { get; set; }
        public long UserId { get; set; }
        public DateTimeOffset EventStart { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Boolean IsKeyPerson { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Created;
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
