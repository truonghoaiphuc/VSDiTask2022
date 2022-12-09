using VSDiTask.Core.Entities.Enums;

namespace VSDiTask.Core.Entities
{
    public class Function : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string DisplayOrder { get; set; }
        public string ParentId { get; set; }
        public string Icon { get; set; }
        public FunctionStatus Status { get; set; }
    }
}
