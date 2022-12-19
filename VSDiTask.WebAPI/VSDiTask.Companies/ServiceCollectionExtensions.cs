using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Services.Services;

namespace VSDiTask.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCompanyServices(this IServiceCollection services)
        {
            return services
                .AddScoped<ICompanyService, CompanyService>();
        }
    }
}
