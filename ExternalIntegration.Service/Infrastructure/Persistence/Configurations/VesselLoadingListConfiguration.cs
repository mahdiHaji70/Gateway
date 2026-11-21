using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class VesselLoadingListConfiguration : IEntityTypeConfiguration<VesselLoadingList>
    {
        public void Configure(EntityTypeBuilder<VesselLoadingList> builder)
        {
            builder.ToTable("VesselLoadingLists");
            builder.HasKey(x => x.Id);
        }
    }
}
