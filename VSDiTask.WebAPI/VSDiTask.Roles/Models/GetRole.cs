namespace VSDiTask.Roles.Models
{
    public class GetRole
    {
        public class RequestRole
        {
            public string? RoleId { get; set; }
        }
        public class Response
        {
            public string? RoleId { get; set; }
            public string? RoleName { get; set; }
            public bool IsAdmin { get; set; }
            public string? Description { get; set; }

            public List<RolePermission> Permissions { get; set; } = new List<RolePermission>();

        }

        public class RolePermission
        {
            public string? RoleId { get; set; }
            public string? FunctionId { get; set; }
            public bool CanRead { get; set; }
            public bool CanCreate { get; set; }
            public bool CanUpdate { get; set; }
            public bool CanDelete { get; set; }
        }

    }
}
