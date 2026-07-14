using ExternalIntegration.Service.Infrastructure.Logging.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class IntegrationLogConfiguration : IEntityTypeConfiguration<PMOLog>
    {
        public void Configure(EntityTypeBuilder<PMOLog> builder)
        {
            builder.ToTable("Logging" ,"PMOLogs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SystemName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.OperationName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.HttpMethod)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Url)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.CorrelationId)
                .HasMaxLength(100);

            builder.Property(x => x.ErrorMessage)
                .HasMaxLength(4000);

            builder.Property(x => x.DurationMs)
                .IsRequired();

            builder.Property(x => x.IsSuccess)
                .IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired();
        }
    }
}
