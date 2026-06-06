using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class DischargePermitConfiguration : IEntityTypeConfiguration<DischargePermit>
    {
        public void Configure(EntityTypeBuilder<DischargePermit> builder)
        {
            builder.ToTable("DischargePermits");

            builder.HasKey(t => t.Id);            
        }
    }
}
