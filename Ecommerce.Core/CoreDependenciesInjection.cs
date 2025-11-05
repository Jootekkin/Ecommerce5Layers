using Ecommerce.Core.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Core
{
    public static class CoreDependenciesInjection
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Register core services, repositories, etc. here
            services.AddAutoMapper(cfg => cfg.AddProfile(typeof(Profiles)));


            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(Behavior.ValidatorBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
