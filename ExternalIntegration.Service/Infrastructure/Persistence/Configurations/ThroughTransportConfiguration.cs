using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class ThroughTransportConfiguration : IEntityTypeConfiguration<ThroughTransport>
    {
        public void Configure(EntityTypeBuilder<ThroughTransport> builder)
        {
            builder.ToTable("ThroughTransports");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TerminalCode).HasMaxLength(50).IsRequired();
        }
    }
}
