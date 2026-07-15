using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
   
    public class StoreReceiptGoodConfiguration : IEntityTypeConfiguration<StoreReceiptGood>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptGood> builder)
        {
            builder.ToTable("StoreReceiptGoods", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Commodity)
            .WithMany(cn => cn.CommodityStoreReceiptGoods)
            .HasForeignKey(c => c.CommodityId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Package)
            .WithMany(cn => cn.PackageStoreReceiptGoods)
            .HasForeignKey(c => c.PackageId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
