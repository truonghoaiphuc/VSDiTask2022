namespace VSDiTask.Core.Settings
{
    public class TokenSetting
    {
        public string SecurityKey { get; set; } = String.Empty;
        public string Issuer { get; set; } = String.Empty;
        public string Audience { get; set; } = String.Empty;
        public int ExpiryMinutes { get; set; } = 60;
    }
}
