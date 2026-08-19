using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ManifestContainerConfiguration : IEntityTypeConfiguration<ManifestContainer>
    {
        public void Configure(EntityTypeBuilder<ManifestContainer> builder)
        {
            builder.ToTable("ManifestContainers", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ManifestItemId)
                .IsRequired();

            builder.Property(x => x.BillOfLadingId)
                .IsRequired(false);

            builder.Property(x => x.SealNumber)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.DangerousCode)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.Classification)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.Property(x => x.IgnitionTemperature)                
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.IgnitionTemperatureUnit)
                .IsRequired(false)
                .HasMaxLength(50);

            builder.HasOne(x => x.Container)
                .WithMany()
                .HasForeignKey(x => x.ContainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ManifestItem)
                .WithMany(x => x.ManifestContainers)
                .HasForeignKey(x => x.ManifestItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
