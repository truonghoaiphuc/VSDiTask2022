using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
