using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
   
    public class StoreReceiptContainerConfiguration : IEntityTypeConfiguration<StoreReceiptContainer>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptContainer> builder)
        {
            builder.ToTable("StoreReceiptContainers", schema: "doc");

            builder.HasKey(x => x.Id);

        }
    }
}
