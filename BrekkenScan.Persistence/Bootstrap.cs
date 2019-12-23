using BrekkenScan.Business;
using BrekkenScan.Domain;
using BrekkenScan.Persistence.Repositories.Brand;
using BrekkenScan.Persistence.Repositories.Consume;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Persistence
{
    public static class Bootstrap
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(connection, b => b.MigrationsAssembly("BrekkenScan.Persistence")));

            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IConsumeStorage, ConsumeStorage>();
            services.AddTransient<IBrandStorage, BrandStorage>();
            return services;
        }
    }
}
