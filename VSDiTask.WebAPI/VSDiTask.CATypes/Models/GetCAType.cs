namespace VSDiTask.CATypes.Models
{
    public class GetCAType
    {
        public class RequestCAType
        {
            public long Id { get; set; }
            public string? CAName { get; set; }
            public string? Description { get; set; }
        }
        public class Response
        {
            public long Id { get; set; }
            public string? CAName { get; set; }
            public string? Description { get; set; }

        }
    }
}
