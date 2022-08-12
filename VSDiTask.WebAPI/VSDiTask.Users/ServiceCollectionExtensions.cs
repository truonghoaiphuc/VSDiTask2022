using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Users.Services;

namespace VSDiTask.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserService, UserService>();
        }
    }
}
