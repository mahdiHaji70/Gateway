using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Infrastructure.Encryption;
using ExternalIntegration.Service.Infrastructure.Persistence;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<GatewayDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITerminalRepository, TerminalRepository>();

            services.AddSingleton<AesEncryption>();

            return services;
        }
    }
}
