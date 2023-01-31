using System.ComponentModel.DataAnnotations;

namespace VSDiTask.Core.Entities
{
    public class Company
    {
        [Key]
        public string CompCode { get; set; }
        public string CompName { get; set; }
        public string CompAddress { get; set; }
        public bool deleted { get; set; }

        public List<Department> Depts { get; set; } = new List<Department>();
    }
}
