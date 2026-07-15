using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
 
    public class StoreReceiptStateConfiguration : IEntityTypeConfiguration<StoreReceiptState>
    {
        public void Configure(EntityTypeBuilder<StoreReceiptState> builder)
        {
            builder.ToTable("StoreReceiptStates", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
