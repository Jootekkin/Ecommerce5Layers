using Ecommerce.Infrastracture.Implement;
using Ecommerce.Infrastracture.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastracture
{
    public static class InfrastractureDependenciesInjection
    {
        public static IServiceCollection AddInfrastractureDependencies(this IServiceCollection services)
        {
            // Register infrastructure services here
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
