namespace VSDiTask.Core.Entities
{
    public class Department : BaseEntity
    {
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public Company Branch { get; set; }
    }
}
