using System.ComponentModel.DataAnnotations;

namespace VSDiTask.Core.Entities
{
    public class Title
    {
        [Key]
        public string TitleId { get; set; }
        public string TitleName { get; set; }
        public string Description { get; set; }
    }
}
