using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ManifestGoodConfiguration : IEntityTypeConfiguration<ManifestGood>
    {
        public void Configure(EntityTypeBuilder<ManifestGood> builder)
        {
            builder.ToTable("ManifestGoods", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PackNb)
                .IsRequired();

            builder.Property(x => x.GrossWeight)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.Property(x => x.NetWeight)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.Property(x => x.Volume)
                .IsRequired()
                .HasColumnType("decimal(18,3)");

            builder.Property(x => x.BrandName)
                .IsRequired(false)
                .HasMaxLength(200);
            
            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.ManifestItemId)
                .IsRequired();

            builder.Property(x => x.CommodityId)
                .IsRequired();

            builder.Property(x => x.PackageId)
                .IsRequired();

            builder.HasOne(x => x.ManifestItem)
                .WithMany(x => x.ManifestGoods)
                .HasForeignKey(x => x.ManifestItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Commodity)
                .WithMany(x => x.CommodityManifestGoods)
                .HasForeignKey(x => x.CommodityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Package)
                .WithMany(x => x.PackageManifestGoods)
                .HasForeignKey(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
