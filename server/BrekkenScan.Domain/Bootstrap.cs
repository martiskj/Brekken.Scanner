using BrekkenScan.Domain.Consume.Create;
using BrekkenScan.Domain.Consume.Read;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Domain
{
    public static class Bootstrap
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ReadConsumeService>();
            services.AddTransient<CreateConsumeService>();
            return services;
        }
    }
}
