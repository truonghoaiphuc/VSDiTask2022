using VSDiTask.Users.Data;

namespace VSDiTask.Services.Models
{
    public class AddCompany
    {
        public class Request
        {
            public string? CompCode { get; set; }
            public string? CompName { get; set; }
            public string? CompAddress { get; set; }
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
