using Ecommerce.Core.Mapping;
using Ecommerce.Core.Product.Queries.Models;
using Ecommerce.Service.Services.ProductService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core
{
    public static class CoreDependenciesInjection
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Register core services, repositories, etc. here
            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(Profiles)));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
