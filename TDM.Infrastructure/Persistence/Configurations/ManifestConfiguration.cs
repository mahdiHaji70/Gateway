using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ManifestConfiguration : IEntityTypeConfiguration<Manifest>
    {
        public void Configure(EntityTypeBuilder<Manifest> builder)
        {
            builder.ToTable("Manifests", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SerialNo)
                .IsRequired()
                 .HasMaxLength(50);

            builder.Property(x => x.ManifestRegistrationNumber)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.VoyageNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.NoticeNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ETA)
                .IsRequired();

            builder.Property(x => x.ETD)
                .IsRequired();

            builder.Property(x => x.TerminalCode)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.ShipLine)
                .HasMaxLength(200);

            builder.Property(x => x.ShipAgent)
                .HasMaxLength(200);

            builder.Property(x => x.VesselName)
                .HasMaxLength(200);

            builder.Property(x => x.Imo)
                .HasMaxLength(20);
        }
    }
}
