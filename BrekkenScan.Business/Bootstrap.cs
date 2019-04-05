using BrekkenScan.Business.Business.Brand.Queries;
using BrekkenScan.Business.Business.Consume.Commands;
using BrekkenScan.Business.Business.Consume.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Business
{
    public static class Bootstrap
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ConsumeViewService>();
            services.AddScoped<ConsumeRegisterService>();
            services.AddScoped<BrandViewService>();
            return services;
        }
    }
}
