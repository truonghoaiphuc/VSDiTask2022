﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VSDiTask.Infrastructure;

namespace VSDiTask.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(
            this IServiceCollection services,
            string connectionString,
            bool sensitiveDataLogging,
            bool detailError
            )
        {
            return services
                .AddVSDiTaskContext(connectionString, sensitiveDataLogging, detailError)
                .AddScoped<IVSDiTaskDbContextFactory, VSDiTaskDbContextFactory>();
        }

        private static IServiceCollection AddVSDiTaskContext(
            this IServiceCollection services,
            string connectionString,
            bool sensitiveDataLogging,
            bool detailError
            )
        {
#if DEBUG
            sensitiveDataLogging = true;
            detailError = true;
#endif
            return services
                .AddDbContextFactory<VSDiTaskDBContext>(builder =>
                {
                    builder.UseSqlServer(connectionString)
                    .EnableSensitiveDataLogging(sensitiveDataLogging)
                    .EnableDetailedErrors(detailError)
#if DEBUG
                    .LogTo(s => System.Diagnostics.Debug.WriteLine(s));
#endif
                });
        }
    }
}
