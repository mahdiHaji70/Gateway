using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class StoreReceiptManifestItemConfiguration
        : IEntityTypeConfiguration<StoreReceiptManifestItem>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptManifestItem> builder)
        {
            builder.ToTable("StoreReceiptManifestItems");

            builder.HasKey(x => new { x.StoreReceiptId, x.IpasItemId });

            builder.HasIndex(x => new { x.IpasItemId, x.StoreReceiptId });

            builder.HasOne(x => x.StoreReceipt)
                .WithMany(x => x.ManifestItemLinks)
                .HasForeignKey(x => x.StoreReceiptId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
