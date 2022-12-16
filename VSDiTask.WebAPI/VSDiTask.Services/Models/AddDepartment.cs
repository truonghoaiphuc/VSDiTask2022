using VSDiTask.Users.Data;

namespace VSDiTask.Services.Models
{
    public class AddDepartment
    {
        public class Request
        {
            public string? DeptCode { get; set; }
            public string? DeptName { get; set; }
            public string? Branch { get; set; }
        }

        public class Response
        {
            public string? Id { get; set; }
            public StatusCode? StatusCode { get; set; }
        }
    }
}
