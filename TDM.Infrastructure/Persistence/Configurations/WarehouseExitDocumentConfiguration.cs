using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class WarehouseExitDocumentConfiguration : IEntityTypeConfiguration<WarehouseExitDocument>
    {
        public void Configure(EntityTypeBuilder<WarehouseExitDocument> builder)
        {
            builder.ToTable("WarehouseExitDocuments", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Serial)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasIndex(x => x.Serial)
                .IsUnique();

            builder.Property(x => x.VehicleNumber)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
