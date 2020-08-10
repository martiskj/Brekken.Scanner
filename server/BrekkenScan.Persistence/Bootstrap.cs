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
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connection)
        {
            services.AddDbContext(connection);
            services.AddPersistenctServices();
            return services;
        }

        private static void AddDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(connection, b => b.MigrationsAssembly("BrekkenScan.Persistence")));
        }

        private static IServiceCollection AddPersistenctServices(this IServiceCollection services)
        {
            services.AddTransient<IConsumeStorage, ConsumeStorage>();
            services.AddTransient<IBrandStorage, BrandStorage>();
            return services;
        }
    }
}
