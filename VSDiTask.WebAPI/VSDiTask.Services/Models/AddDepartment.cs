using VSDiTask.Users.Data;

namespace VSDiTask.Services.Models
{
    public class AddDepartment
    {
        public class RequestDept
        {
            public string? DeptCode { get; set; }
            public string? DeptName { get; set; }
            public string? Branch { get; set; }
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
