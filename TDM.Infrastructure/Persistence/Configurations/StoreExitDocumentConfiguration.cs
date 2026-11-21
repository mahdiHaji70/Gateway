using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class StoreExitDocumentConfiguration : IEntityTypeConfiguration<StoreExitDocument>
    {
        public void Configure(EntityTypeBuilder<StoreExitDocument> builder)
        {
            builder.ToTable("StoreExitDocuments", schema: "doc");

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
