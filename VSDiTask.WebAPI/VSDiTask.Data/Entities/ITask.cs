namespace VSDiTask.Core.Entities
{
    public class ITask : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        public string Title { get; set; }
        public int Priority { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Created;
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public bool IsPrivate { get; set; } = false;
        public bool deleted { get; set; } = false;

        public List<ITaskSchedule> ITaskSchedules { get; set; }
    }
}
