using VSDiTask.Users.Data;

namespace VSDiTask.Roles.Models
{
    public class CreateRole
    {
        public class RequestRole
        {
            public string? RoleId { get; set; }
            public string? RoleName { get; set; }
            public bool IsAdmin { get; set; }
            public string? Description { get; set; }
        }

        public class Response : Result
        {
            public bool Success { get; set; }

            public Response(bool success)
            {
                Success = success;
            }
            public Response(StatusCode statusCode)
            {
                StatusCode = statusCode;
            }
        }
    }
}
