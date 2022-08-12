using VSDiTask.Core.Settings;

namespace VSDiTask.WebAPI.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<TokenSetting>(configuration.GetSection("JwtConfig"))
                .AddScoped<ITokenService, TokenService>();
        }
    }
}
