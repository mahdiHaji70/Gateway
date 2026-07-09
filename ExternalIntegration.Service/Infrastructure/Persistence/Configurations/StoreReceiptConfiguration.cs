using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class StoreReceiptConfiguration : IEntityTypeConfiguration<StoreReceipt>
    {
        public void Configure(EntityTypeBuilder<StoreReceipt> builder)
        {
            builder.ToTable("StoreReceipts");

            builder.HasKey(t => t.Id);            
        }
    }
}
