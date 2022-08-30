using VSDiTask.Users.Data;

namespace VSDiTask.Services.Models
{
    public class AddCompany
    {
        public class Request
        {
            public string CompanyCode { get; set; }
            public string CompanyName { get; set; }
            public string CompanyAddress { get; set; }
        }

        public class Response
        {
            public long Id { get; set; }
            public StatusCode? StatusCode { get; set; }
        }
    }
}
