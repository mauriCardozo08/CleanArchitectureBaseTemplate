using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Domain
{
    public static class DomainModule
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
