using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ManifestContainerGoodConfiguration : IEntityTypeConfiguration<ManifestContainerGood>
    {
        public void Configure(EntityTypeBuilder<ManifestContainerGood> builder)
        {
            builder.ToTable("ManifestContainerGoods", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PackNb)
                .IsRequired();

            builder.Property(x => x.GrossWeight)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.Property(x => x.NetWeight)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.Property(x => x.ManifestContainerId)
                .IsRequired();

            builder.Property(x => x.PackageId)
                .IsRequired();

            builder.Property(x => x.CommodityId)
                .IsRequired();

            builder.HasOne(x => x.ManifestContainer)
                .WithMany(x => x.ManifestContainerGoods)
                .HasForeignKey(x => x.ManifestContainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Package)
                .WithMany(x => x.PackageManifestContainerGoods)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Commodity)
                .WithMany(x => x.CommodityManifestContainerGoods)
                .HasForeignKey(x => x.CommodityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
