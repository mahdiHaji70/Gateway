using ExternalIntegration.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Configurations
{
    public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder)
        {
            builder.ToTable("Terminals");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(5);

            builder.Property(t => t.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Password)
                   .IsRequired();

            builder.Property(t => t.PortCode)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.HasIndex(t => t.Code)
                   .IsUnique();
        }
    }
}
