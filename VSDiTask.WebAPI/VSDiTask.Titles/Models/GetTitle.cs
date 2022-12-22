namespace VSDiTask.Roles.Models
{
    public class GetTitle
    {
        public class RequestRole
        {
        }
        public class Response
        {
            public string? TitleId { get; set; }
            public string? TitleName { get; set; }
            public string? Description { get; set; }

        }
    }
}
