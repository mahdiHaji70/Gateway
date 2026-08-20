using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Infrastructure.Encryption;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Auth;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Config;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Handlers;
using ExternalIntegration.Service.Infrastructure.Logging.Abstractions;
using ExternalIntegration.Service.Infrastructure.Logging.Services;
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
            services.AddScoped<IGoodwayBillRepository, GoodwayBillRepository>();
            services.AddScoped<IDischargePermitRepository, DischargePermitRepository>();
            services.AddScoped<IIssueRequestRepository, IssueRequestRepository>();
            services.AddScoped<IVoyageRepository, VoyageRepository>();
            services.AddScoped<IStoreReceiptRepository, StoreReceiptRepository>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<IManifestChangeRepository, ManifestChangeRepository>();

            services.AddSingleton<AesEncryption>();

            services.AddHttpClient<PmoAuthService>()
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    SslProtocols = System.Security.Authentication.SslProtocols.Tls12
                });

            services.Configure<PmoServiceNames>(configuration.GetSection("PmoServices"));

            services.AddMemoryCache();

            services.AddScoped<IIntegrationActivityLogger, IntegrationActivityLogger>();

            services.AddTransient<PMOLoggingHandler>();

            services.AddHttpClient<IPmoRequestExecutor, PmoRequestExecutor>()
                .AddHttpMessageHandler<PMOLoggingHandler>();

            services.AddScoped<IPmoClient, PmoClient>();

            return services;
        }
    }
}
