namespace VSDiTask.Core.Entities
{
    public class ITaskDiscuss : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        public long STaskId { get; set; }
        public string Content { get; set; }
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
