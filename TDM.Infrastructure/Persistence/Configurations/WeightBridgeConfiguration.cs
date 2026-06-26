using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    internal class WeightBridgeConfiguration : IEntityTypeConfiguration<WeightBridge>
    {
        public void Configure(EntityTypeBuilder<WeightBridge> builder)
        {
            builder.ToTable("WeightBridges", schema: "operation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DeclarationId)
                .IsRequired();

            builder.Property(x => x.GateId)
              .IsRequired();

        }
   
    }
}
