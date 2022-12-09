namespace VSDiTask.Core.Entities
{
    public class CAStep : BaseEntity
    {
        public long CATypeId { get; set; }
        public string StepName { get; set; }
        public int StepOrder { get; set; }
        public int Duration { get; set; }
    }
}
