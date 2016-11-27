using CustomService.Data;
using CustomService.Model;
using CustomService.OData;
using CustomService.OData.Edm;

using Microsoft.Extensions.DependencyInjection;

using Sitecore.Services.Core.Data;

namespace CustomService.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomService(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IReadOnlyEntityRepository<Customer>, InMemoryReadOnlyEntityRepository>()
                .AddScoped<IReadOnlyEntityRepository<Order>, InMemoryReadOnlyEntityRepository>()
                .AddScoped(provider => new CustomServiceDescriptor(new CustomServiceEdmBuilder()))
                .AddScoped<IReadWriteEntityRepository<Todo>, TodoRepository>()
                ;
        }
    }
}