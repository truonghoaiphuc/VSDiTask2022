using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VSDiTask.Core.Entities
{
    public class Department
    {
        [Key]
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        [ForeignKey("Company")]
        public string Branch { get; set; }
        public Company Company { get; set; }
        public bool deleted { get; set; }
    }
}
