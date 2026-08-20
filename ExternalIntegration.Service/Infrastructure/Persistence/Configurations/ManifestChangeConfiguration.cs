using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class ManifestChangeConfiguration : IEntityTypeConfiguration<ManifestChange>
    {
        public void Configure(EntityTypeBuilder<ManifestChange> builder)
        {
            builder.ToTable("ManifestChanges");

            builder.HasKey(t => t.Id);            
        }
    }
}
