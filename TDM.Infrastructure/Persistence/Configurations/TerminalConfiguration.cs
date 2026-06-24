using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class TerminalConfiguration : IEntityTypeConfiguration<Terminal>
    {
        public void Configure(EntityTypeBuilder<Terminal> builder)
        {
            builder.ToTable("Terminals", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.PortCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
