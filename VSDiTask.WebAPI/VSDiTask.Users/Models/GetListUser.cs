using VSDiTask.Core.Entities.Enums;

namespace VSDiTask.Users.Models
{
    public class GetListUser
    {
        public class Request
        {
            public string userName { get; set; }
        }
        public class Response
        {
            public long Id { get; set; }
            public string UserName { get; set; }
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
            public DateTimeOffset createdDate { get; set; }
            public string? createdId { get; set; }
            public DateTimeOffset updateDate { get; set; }
            public string? updateId { get; set; }
        }
    }
}
