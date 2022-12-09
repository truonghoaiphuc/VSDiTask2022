namespace VSDiTask.Core.Entities
{
    public class Role : BaseEntity
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public Boolean IsAdmin { get; set; } = false;
    }
}
