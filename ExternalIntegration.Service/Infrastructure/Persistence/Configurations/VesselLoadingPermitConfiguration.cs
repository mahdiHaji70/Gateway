using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class VesselLoadingPermitConfiguration : IEntityTypeConfiguration<VesselLoadingPermit>
    {
        public void Configure(EntityTypeBuilder<VesselLoadingPermit> builder)
        {
            builder.ToTable("VesselLoadingPermits");

            builder.HasKey(t => t.Id);            
        }
    }
}
