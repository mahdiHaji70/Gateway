using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class TallyQuantityVarianceConfiguration : IEntityTypeConfiguration<TallyQuantityVariance>
    {
        public void Configure(EntityTypeBuilder<TallyQuantityVariance> builder)
        {
            builder.ToTable("TallyQuantityVariances");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TerminalCode).HasMaxLength(50).IsRequired();
            builder.Property(x => x.VoyageNoticeNo).IsRequired(false);
            builder.Property(x => x.Berth).IsRequired(false);
            builder.Property(x => x.Vessel).IsRequired(false);
            builder.Property(x => x.VoyageShippingLineId).IsRequired(false);
            builder.Property(x => x.VoyageShippingLine).IsRequired(false);
            builder.Property(x => x.ShippingAgent).IsRequired(false);
            builder.Property(x => x.ShippingAgentIdNumber).IsRequired(false);
            builder.HasIndex(x => new { x.TerminalCode, x.VoyageId });
        }
    }
}
