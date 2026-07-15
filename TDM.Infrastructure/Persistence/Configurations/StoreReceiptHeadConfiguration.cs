using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    
    public class StoreReceiptHeadConfiguration : IEntityTypeConfiguration<StoreReceiptHead>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptHead> builder)
        {
            builder.ToTable("StoreReceiptHeads", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.Traffic)
           .WithMany(cn => cn.TrafficStoreReceiptHeads)
           .HasForeignKey(c => c.TrafficId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Consignee)
            .WithMany(cn => cn.ConsigneeStoreReceiptHeads)
            .HasForeignKey(c => c.ConsigneeId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ConsigneeRep)
            .WithMany(cn => cn.ConsigneeRepStoreReceiptHeads)
            .HasForeignKey(c => c.ConsigneeRepId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CargoType)
            .WithMany(cn => cn.CargoTypeStoreReceiptHeads)
            .HasForeignKey(c => c.CargoTypeId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.StoreReceiptState)
          .WithMany(cn => cn.StoreReceiptStateStoreReceiptHeads)
          .HasForeignKey(c => c.StoreReceiptStateId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ArrivalType)
         .WithMany(cn => cn.ArrivalTypeStoreReceiptHeads)
         .HasForeignKey(c => c.ArrivalTypeId)
         .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
