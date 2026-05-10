using ExternalIntegration.Service.Integrations.PMO.Auth;
using ExternalIntegration.Service.Integrations.PMO.Client;
using ExternalIntegration.Service.Integrations.PMO.Config;

namespace ExternalIntegration.Service.Integrations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<PmoAuthService>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    SslProtocols = System.Security.Authentication.SslProtocols.Tls12
                });

            services.Configure<PmoServiceNames>(configuration.GetSection("PmoServices"));

            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            services.AddHttpClient<IPmoRequestExecutor, PmoRequestExecutor>();

            services.AddScoped<IPmoClient, PmoClient>();

            return services;
        }
    }
}
