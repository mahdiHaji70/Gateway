using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.ToTable("Voyages");

            builder.HasKey(t => t.Id);            
        }
    }
}
