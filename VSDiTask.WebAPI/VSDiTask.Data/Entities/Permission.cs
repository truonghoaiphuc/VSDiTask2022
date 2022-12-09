namespace VSDiTask.Core.Entities
{
    public class Permission : BaseEntity
    {
        public Role RoleId { get; set; }
        public Function FunctionId { get; set; }
        public bool CanRead { get; set; }
        public bool CanCreate { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }
}
