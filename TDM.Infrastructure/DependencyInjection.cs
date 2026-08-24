using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDM.Application.Common.Interfaces;
using TDM.Infrastructure.Integrations.Auth;
using TDM.Infrastructure.Integrations.Client;
using TDM.Infrastructure.Persistence;
using TDM.Infrastructure.Persistence.Repositories;

namespace TDM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<TDMDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient<IRequestExecutor, RequestExecutor>();
            services.AddHttpClient<AuthService>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ITrafficRepository, TrafficRepository>();
            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<IUserTerminalRepository, UserTerminalRepository>();
            services.AddScoped<IDeclarationRepository, DeclarationRepository>();
            services.AddScoped<IDeclarationItemRepository, DeclarationItemRepository>();
            services.AddScoped<IDeclarationExternalService, DeclarationExternalService>();
            services.AddScoped<ICargoTypeRepository, CargoTypeRepository>();
            services.AddScoped<IStoreTypeRepository, StoreTypeRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ITerminalDischargeRepository, TerminalDischargeRepository>();
            services.AddScoped<ITerminalDischargeExternalService, TerminalDischargeExternalService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IGateRepository, GateRepository>();
            services.AddScoped<IWeightBridgeRepository, WeightBridgeRepository>();
            services.AddScoped<IIssueRequestStoreReceiptExternalService, IssueRequestStoreReceiptExternalService>();
            services.AddScoped<IStoreReceiptHeadRepository, StoreReceiptHeadRepository>();
            services.AddScoped<IStoreReceiptGoodRepository, StoreReceiptGoodRepository>();
            services.AddScoped<IStoreReceiptContainerRepository, StoreReceiptContainerRepository>();
            services.AddScoped<IStoreReceiptContainerGoodRepository, StoreReceiptContainerGoodRepository>();
            services.AddScoped<IStoreReceiptExternalService, StoreReceiptExternalService>();
            services.AddScoped<IManifestExternalService, ManifestExternalService>();
            services.AddScoped<IManifestRepository, ManifestRepository>();
            services.AddScoped<IVesselDischargeRepository, VesselDischargeRepository>();
            services.AddScoped<IVesselDischargeExternalService, VesselDischargeExternalService>();


            return services;
        }
    }
}
