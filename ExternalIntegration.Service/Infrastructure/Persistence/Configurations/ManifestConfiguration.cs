using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class ManifestConfiguration : IEntityTypeConfiguration<Manifest>
    {
        public void Configure(EntityTypeBuilder<Manifest> builder)
        {
            builder.ToTable("Manifests");

            builder.HasKey(t => t.Id);            
        }
    }
}
