namespace VSDiTask.Core.Entities
{
    public class Permission : BaseEntity
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string FunctionId { get; set; }
        public Function Function { get; set; }
        public bool CanRead { get; set; } = false;
        public bool CanCreate { get; set; } = false;
        public bool CanUpdate { get; set; } = false;
        public bool CanDelete { get; set; } = false;
    }
}
