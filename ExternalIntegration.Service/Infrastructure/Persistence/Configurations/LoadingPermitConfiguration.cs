using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class LoadingPermitConfiguration : IEntityTypeConfiguration<LoadingPermit>
    {
        public void Configure(EntityTypeBuilder<LoadingPermit> builder)
        {
            builder.ToTable("LoadingPermits");

            builder.HasKey(t => t.InternalId);

            builder.Property(t => t.InternalId)
                .ValueGeneratedOnAdd();

            builder.HasIndex(t => new { t.Id, t.ExpirationDate })
                .IsUnique();

            builder.Property(t => t.IsApproved)
           .HasColumnName("IsApproved")
           .IsRequired()
           .HasDefaultValue(0);
        }
    }
}
