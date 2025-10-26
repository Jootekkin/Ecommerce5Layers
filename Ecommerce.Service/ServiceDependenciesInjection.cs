using Ecommerce.Service.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service
{
    public static class ServiceDependenciesInjection
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {

            // Register service layer dependencies here
            services.Scan(scan => scan
                .FromAssemblyOf<ProductService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
