using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
    {
        public void Configure(EntityTypeBuilder<Voyage> builder)
        {
            builder.ToTable("Voyages", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NoticeDate).HasColumnType("datetime2(7)");
            builder.HasIndex(x => x.IpasVoyageId).IsUnique().HasFilter("[IpasVoyageId] IS NOT NULL");

            builder.Property(x => x.VoyageNo).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(x => x.NoticeNo).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(x => x.ETA).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(x => x.ETD).HasColumnType("datetime2(7)").IsRequired();
            builder.Property(x => x.ShipLine).HasMaxLength(200).IsUnicode().IsRequired();
            builder.Property(x => x.ShipAgent).HasMaxLength(200).IsUnicode().IsRequired();
            builder.Property(x => x.VesselName).HasMaxLength(200).IsUnicode().IsRequired();
            builder.Property(x => x.Imo).HasMaxLength(20).IsUnicode().IsRequired();
        }
    }
}
