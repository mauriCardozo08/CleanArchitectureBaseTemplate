using CleanArchitecture.Application.Abstractions.Services;
using CleanArchitecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();
            return services;
        }
    }
}
