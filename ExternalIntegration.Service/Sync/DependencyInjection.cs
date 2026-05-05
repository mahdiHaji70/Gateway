

using ExternalIntegration.Service.Sync.AutoMapper;
using ExternalIntegration.Service.Sync.PMO;

namespace ExternalIntegration.Service.Sync
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSync(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => { }, typeof(PmoSyncProfile));

            services.AddScoped<IPmoSyncService, PmoSyncService>();

            return services;
        }
    }
}
