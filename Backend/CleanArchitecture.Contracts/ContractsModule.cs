using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Contracts
{
    public static class ContractsModule
    {
        public static IServiceCollection AddContractsModule(this IServiceCollection services)
        {
            return services;
        }
    }
}
