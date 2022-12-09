namespace VSDiTask.Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompCode { get; set; }
        public string CompName { get; set; }
        public string CompAddress { get; set; }

        public List<Department> Depts { get; set; } = new List<Department>();
    }
}
