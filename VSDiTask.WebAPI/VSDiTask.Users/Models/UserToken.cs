namespace VSDiTask.Users.Models
{
    public class UserToken
    {
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + "" + LastName;
        public string Role { get; set; } = string.Empty;
    }
}
