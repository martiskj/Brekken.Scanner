using BrekkenScan.Domain;
using Microsoft.AspNetCore.Identity;
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
    }
}
