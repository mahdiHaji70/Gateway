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

        }
    }
}
