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

        }
    }
}
