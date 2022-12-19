using VSDiTask.Core.Entities.Enums;

namespace VSDiTask.Users.Models
{
    public class GetUser
    {
        public class Request
        {
            public string userName { get; set; }
        }
        public class Response
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName => FirstName + " " + LastName;
            public string PhoneNumber { get; set; }
            public string Address { get; set; }
            public bool Gender { get; set; }
            public DateTimeOffset DateOfBirth { get; set; }
            public string Avatar { get; set; }
            public UserStatus Status { get; set; }
            public string DeptId { get; set; }
            public string DeptName { get; set; }
            public string RoleId { get; set; }
            public string RoleName { get; set; }

            public List<UserPermission> Permissions { get; set; } = new List<UserPermission>();

        }

        public class UserPermission
        {
            public string? RoleId { get; set; }
            public string? FunctionId { get; set; }
            public bool CanRead { get; set; }
            public bool CanCreate { get; set; }
            public bool CanUpdate { get; set; }
            public bool CanDelete { get; set; }
        }
    }
}
