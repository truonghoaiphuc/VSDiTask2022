using VSDiTask.Core.Entities.Enums;
using VSDiTask.Users.Data;

namespace VSDiTask.Users.Models
{
    public class CreateUser
    {
        public class RequestUser
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
            public UserStatus Status { get; set; }
            public string DeptId { get; set; }
            public string RoleId { get; set; }
        }

        public class ResponseUser : Result
        {
            public long Id { get; set; }
            public bool Success { get; set; }

            public ResponseUser(bool success)
            {
                Success = success;
            }
            public ResponseUser(StatusCode statusCode)
            {
                StatusCode = statusCode;
            }
        }
    }
}
