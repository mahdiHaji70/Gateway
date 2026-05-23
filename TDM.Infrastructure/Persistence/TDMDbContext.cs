using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Common;
using TDM.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TDM.Infrastructure.Persistence
{
    public class TDMDbContext : DbContext
    {
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Commodity> Commodities => Set<Commodity>();

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
