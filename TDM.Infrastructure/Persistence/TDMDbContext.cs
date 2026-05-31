using Microsoft.EntityFrameworkCore;
using TDM.Domain.Common;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence
{
    public class TDMDbContext : DbContext
    {
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Commodity> Commodities => Set<Commodity>();
        public DbSet<Traffic> Traffics => Set<Traffic>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Declaration> Declarations => Set<Declaration>();
        public DbSet<DeclarationItem> DeclarationItems => Set<DeclarationItem>();

        public TDMDbContext(DbContextOptions<TDMDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(TDMDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInformation()
        {
            var entries = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added && entry.Entity.CreatedAt == default)
                {
                    entry.Entity.SetCreatedAudit();
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.SetUpdatedAudit();
                }
            }
        }
    }
}
