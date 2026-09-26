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

            builder.HasKey(t => t.InternalId);

            builder.Property(t => t.InternalId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(t => t.Id)
                .IsUnique();

            builder.Property(t => t.LastUpdateDate);

            builder.Property(t => t.IsApproved)
           .HasColumnName("IsApproved")
           .IsRequired()
           .HasDefaultValue(0);
        }
    }
}
