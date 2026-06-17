using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class TerminalDischargeConfiguration:IEntityTypeConfiguration<TerminalDischarge>
    {
        public void Configure(EntityTypeBuilder<TerminalDischarge> builder)
        {
            builder.ToTable("TerminalDischarges", schema: "operation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TerminalCode)
                .IsRequired()
               .HasMaxLength(4);

            builder.Property(x => x.CargoTypeId)
               .IsRequired();

            builder.Property(x => x.DeclarationItemId)
              .IsRequired();

            builder.Property(x => x.DischargeDate)
             .IsRequired();

            builder.Property(x => x.PackNB)
              .IsRequired();

            builder.Property(x => x.Weight)
              .IsRequired();


            builder.HasOne(c => c.DeclarationItem)
          .WithMany(cn => cn.TerminalDischarges)
          .HasForeignKey(c => c.DeclarationItemId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.CargoType)
           .WithMany(cn => cn.CargoTypeTerminalDischarges)
           .HasForeignKey(c => c.StoreId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Store)
            .WithMany(cn => cn.StoreTerminalDischarges)
            .HasForeignKey(c => c.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
