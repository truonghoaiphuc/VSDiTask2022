using System.ComponentModel.DataAnnotations;

namespace VSDiTask.Core.Entities
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean IsAdmin { get; set; } = false;
        public string Description { get; set; }
        public bool deleted { get; set; }

        public List<Permission> Permissions { get; set; } = new List<Permission>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
