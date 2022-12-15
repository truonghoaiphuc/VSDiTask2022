namespace VSDiTask.Core.Entities
{
    public class CAType : BaseEntity
    {
        public string CAName { get; set; }
        public List<CAStep> CASteps { get; set; } = new List<CAStep>();
    }
}
