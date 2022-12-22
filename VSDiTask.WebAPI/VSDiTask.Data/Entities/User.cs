using System.ComponentModel.DataAnnotations.Schema;
using VSDiTask.Core.Entities.Enums;

namespace VSDiTask.Core.Entities
{
    public class User : BaseEntity, ICreatedEntity, IUpdateEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
        [ForeignKey("Department")]
        public string DeptId { get; set; }
        public Department Department { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string TitleId { get; set; }
        public Title Title { get; set; }


        public List<Permission> Permissions { get; set; } = new List<Permission>();

        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
