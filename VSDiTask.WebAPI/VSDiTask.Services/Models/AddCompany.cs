using VSDiTask.Users.Data;

namespace VSDiTask.Services.Models
{
    public class AddCompany
    {
        public class Request
        {
            public string CompCode { get; set; }
            public string CompName { get; set; }
            public string CompAddress { get; set; }
        }

        public class Response
        {
            public string Id { get; set; }
            public StatusCode? StatusCode { get; set; }
        }
    }
}
