namespace VSDiTask.Services.Models
{
    public class GetListCompany
    {
        public class Request
        {
            public string? compCode { get; set; }
            public string? compName { get; set; }
            public string? compAddress { get; set; }
        }

        public class Response
        {
            public string? compCode { get; set; }
            public string? compName { get; set; }
            public string? compAddress { get; set; }
            public List<GetListDepartment.Response>? Depts { get; set; }
        }
    }
}
