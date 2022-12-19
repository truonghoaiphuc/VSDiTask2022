namespace VSDiTask.Services.Models
{
    public class GetListDepartment
    {
        public class Request
        {
            public string? deptCode { get; set; }
            public string? deptName { get; set; }
            public string? branch { get; set; }
        }

        public class Response
        {
            public string? deptCode { get; set; }
            public string? deptName { get; set; }
            public string? branch { get; set; }
        }
    }
}
