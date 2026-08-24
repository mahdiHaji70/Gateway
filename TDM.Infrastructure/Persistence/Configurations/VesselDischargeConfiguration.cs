using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class VesselDischargeConfiguration : IEntityTypeConfiguration<VesselDischarge>
    {
        public void Configure(EntityTypeBuilder<VesselDischarge> builder)
        {
            builder.ToTable("VesselDischarges", schema: "operation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TerminalCode)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(x => x.StoreId)
                .IsRequired();

            builder.Property(x => x.ManifestItemId)
                .IsRequired();

            builder.Property(x => x.DischargeDate)
                .IsRequired();

            builder.Property(x => x.PackNB)
                .IsRequired();

            builder.Property(x => x.Weight)
                .IsRequired()
                .HasPrecision(18, 3);

            builder.Property(x => x.Volume)
                .IsRequired()
                .HasPrecision(18, 3);

            builder.Property(x => x.UnitWeight)
                .IsRequired()
                .HasPrecision(18, 3)
                .HasDefaultValue(0);

            builder.Property(x => x.IsNonPalletized)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsDamaged)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsVoluminous)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.IsDangerous)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(x => x.DangerousCode)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.Classification)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.IgnitionTemperature)
                .IsRequired(false)
                .HasPrecision(18, 3);

            builder.Property(x => x.IgnitionTemperatureUnit)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(x => x.IpasVesselDischargeId)
                .IsRequired(false);

            builder.Property(x => x.IpasVesselDischargeReceivedAt)
                .IsRequired(false);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.StoreVesselDischarges)
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ManifestItem)
                .WithMany(x => x.ManifestItemVesselDischarges)
                .HasForeignKey(x => x.ManifestItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ManifestContainer)
                .WithMany(x => x.ManifestContainerVesselDischarges)
                .HasForeignKey(x => x.ManifestContainerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.StoreId);

            builder.HasIndex(x => x.ManifestItemId);

            builder.HasIndex(x => x.IpasVesselDischargeId)
                .IsUnique()
                .HasFilter("[IpasVesselDischargeId] IS NOT NULL");
        }
    }
}
