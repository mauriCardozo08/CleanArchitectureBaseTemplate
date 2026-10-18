using CleanArchitecture.Application.Abstractions.Repositories;
using CleanArchitecture.Infrastructure.Database.App;
using CleanArchitecture.Infrastructure.Database.App.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            services.AddScoped<ISampleRepository, SampleRepository>();

            return services;
        }
    }
}
