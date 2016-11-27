using CustomService.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Services.Infrastructure.Sitecore.DependencyInjection;

namespace CustomService.DependencyInjection
{
    public class CustomServiceConfigurator 
        : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            var assemblies = new[] { GetType().Assembly };

            serviceCollection
                .AddWebApiControllers(assemblies);

            serviceCollection
                .AddCustomService();
        }
    }
}