namespace VSDiTask.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
    }

    public interface ICreatedEntity
    {
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public interface IUpdateEntity
    {
        public string CreatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
