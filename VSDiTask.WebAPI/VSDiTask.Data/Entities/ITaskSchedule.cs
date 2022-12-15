namespace VSDiTask.Core.Entities
{
    public class ITaskSchedule : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        public long ITaskId { get; set; }
        public ITask ITask { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public DateTimeOffset EventStart { get; set; }
        public DateTimeOffset Deadline { get; set; }
        public Boolean IsKeyPerson { get; set; } = false;
        public TaskStatus Status { get; set; } = TaskStatus.Created;
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public List<ITaskDiscuss> ITaskDiscusses { get; set; } = new List<ITaskDiscuss>();
    }
}
