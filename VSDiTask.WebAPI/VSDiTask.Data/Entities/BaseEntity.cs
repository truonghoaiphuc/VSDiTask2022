using System.ComponentModel.DataAnnotations;

namespace VSDiTask.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public string Description { get; set; }
    }

    public interface ICreatedEntity
    {
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public interface IUpdateEntity
    {
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
