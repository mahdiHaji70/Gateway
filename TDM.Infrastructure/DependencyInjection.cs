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
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IDeclarationRepository, DeclarationRepository>();
            services.AddScoped<IDeclarationItemRepository, DeclarationItemRepository>();
            services.AddScoped<IDeclarationExternalService, DeclarationExternalService>();
            services.AddScoped<ICargoTypeRepository, CargoTypeRepository>();
            services.AddScoped<IStoreTypeRepository, StoreTypeRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ITerminalDischargeRepository, TerminalDischargeRepository>();

            return services;
        }
    }
}
