using VSDiTask.Users.Data;

namespace VSDiTask.CATypes.Models
{
    public class CreateCAType
    {
        public class RequestCAType
        {
            public long Id { get; set; }
            public string CAName { get; set; }
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
