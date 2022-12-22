using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Roles.Services;

namespace VSDiTask.Roles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTitleServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ITitleService, TitleService>();
        }
    }
}
