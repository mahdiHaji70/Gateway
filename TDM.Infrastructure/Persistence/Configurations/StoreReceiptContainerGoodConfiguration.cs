using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
 
    public class StoreReceiptContainerGoodConfiguration : IEntityTypeConfiguration<StoreReceiptContainerGood>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptContainerGood> builder)
        {
            builder.ToTable("StoreReceiptContainerGoods", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Commodity)
            .WithMany(cn => cn.CommodityStoreReceiptContainerGoods)
            .HasForeignKey(c => c.CommodityId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Package)
            .WithMany(cn => cn.PackageStoreReceiptContainerGoods)
            .HasForeignKey(c => c.PackageId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
