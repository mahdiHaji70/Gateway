using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class StoreReceiptOperationConfiguration : IEntityTypeConfiguration<StoreReceiptOperation>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptOperation> builder)
        {
            builder.ToTable("StoreReceiptOperations", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.StoreReceiptHead)
                .WithMany(x => x.StoreReceiptOperations)
                .HasForeignKey(x => x.StoreReceiptHeadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.StoreReceiptContainer)
                .WithMany(x => x.StoreReceiptOperations)
                .HasForeignKey(x => x.StoreReceiptContainerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OperationType)
                .WithMany(x => x.StoreReceiptOperations)
                .HasForeignKey(x => x.OperationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Service)
                .WithMany(x => x.StoreReceiptOperations)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Store)
                .WithMany(x => x.StoreReceiptOperations)
                .HasForeignKey(x => x.StoreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
