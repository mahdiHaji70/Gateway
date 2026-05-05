using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class GoodwayBillConfiguration : IEntityTypeConfiguration<GoodwayBill>
    {
        public void Configure(EntityTypeBuilder<GoodwayBill> builder)
        {
            builder.ToTable("GoodwayBills");

            builder.HasKey(t => t.Id);            
        }
    }
}
