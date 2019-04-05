﻿using BrekkenScan.Business.Business.Brand.Create;
using BrekkenScan.Business.Business.Brand.Get;
using BrekkenScan.Business.Business.Brand.Update;
using BrekkenScan.Business.Business.Consume.Create;
using BrekkenScan.Business.Business.Consume.Get;
using Microsoft.Extensions.DependencyInjection;

namespace BrekkenScan.Business
{
    public static class Bootstrap
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ConsumeCreateService>();
            services.AddScoped<ConsumeReadService>();

            services.AddScoped<BrandCreateService>();
            services.AddScoped<BrandReadService>();
            services.AddScoped<BrandUpdateService>();
            return services;
        }
    }
}
