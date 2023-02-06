using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Roles.Services;

namespace VSDiTask.CATypes
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCATypeServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICATypeService, CATypeService>();
        }
    }
}
