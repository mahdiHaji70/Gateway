using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    
    public class ArrivalTypeConfiguration : IEntityTypeConfiguration<ArrivalType>
    {
        public void Configure(EntityTypeBuilder<ArrivalType> builder)
        {
            builder.ToTable("ArrivalTypes", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
