using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ManifestItemConfiguration : IEntityTypeConfiguration<ManifestItem>
    {
        public void Configure(EntityTypeBuilder<ManifestItem> builder)
        {
            builder.ToTable("ManifestItems", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ManifestItemNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ManifestNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Consignor)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.ShipLine)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(x => x.ManifestId)
                .IsRequired();

            builder.Property(x => x.TrafficId)
                .IsRequired();

            builder.Property(x => x.ConsigneeId)
                .IsRequired();

            builder.Property(x => x.ShipAgentId)
                .IsRequired();

            builder.HasOne(x => x.Manifest)
                .WithMany(x => x.ManifestItems)
                .HasForeignKey(x => x.ManifestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Traffic)
                .WithMany(x => x.TrafficManifestItems)
                .HasForeignKey(x => x.TrafficId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Consignee)
                .WithMany(x => x.ConsigneeManifestItems)
                .HasForeignKey(x => x.ConsigneeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ShipAgent)
                .WithMany(x => x.ShipAgentManifestItems)
                .HasForeignKey(x => x.ShipAgentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
