using BrekkenScan.Application.Consume;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Web
{
    internal static class ServiceRegistrator
    {
        internal static IServiceCollection RegisterBrekkenServices(this IServiceCollection services)
        {
            services.AddScoped<GetConsumeService>();
            return services;
        }
    }
}
