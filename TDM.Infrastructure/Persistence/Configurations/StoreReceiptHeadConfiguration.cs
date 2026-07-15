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

        }
    }

}
