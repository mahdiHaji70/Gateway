using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Context
{
    public class GatewayDbContext : DbContext
    {
        public GatewayDbContext(DbContextOptions<GatewayDbContext> options)
        : base(options)
        {
        }

        public DbSet<Terminal> Terminals => Set<Terminal>();
        public DbSet<GoodwayBill> GoodwayBills => Set<GoodwayBill>();
        public DbSet<DischargePermit> DischargePermits => Set<DischargePermit>();
        public DbSet<IssueRequest> IssueRequests => Set<IssueRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GatewayDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
