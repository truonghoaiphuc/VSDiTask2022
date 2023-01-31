using VSDiTask.Users.Data;

namespace VSDiTask.Titles.Models
{
    public class CreateTitle
    {
        public class RequestTitle
        {
            public string TitleId { get; set; }
            public string TitleName { get; set; }
            public string Description { get; set; }
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
