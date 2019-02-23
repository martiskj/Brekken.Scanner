using BrekkenScan.Application.Consume;
using BrekkenScan.Business.Business.Consume.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Web
{
    internal static class ServiceRegistrator
    {
        internal static IServiceCollection RegisterBrekkenServices(this IServiceCollection services)
        {
            services.AddScoped<GetConsumeService>();
            services.AddScoped<PostConsumeService>();
            return services;
        }
    }
}
