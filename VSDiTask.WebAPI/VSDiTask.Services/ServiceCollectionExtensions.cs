using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Services.Services;

namespace VSDiTask.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDepartmentServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IDepartmentService, DepartmentService>();
        }
    }
}
