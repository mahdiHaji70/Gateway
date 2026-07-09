using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class IssueRequestConfiguration : IEntityTypeConfiguration<IssueRequest>
    {
        public void Configure(EntityTypeBuilder<IssueRequest> builder)
        {
            builder.ToTable("IssueRequests");

            builder.HasKey(t => t.Id);            
        }
    }
}
