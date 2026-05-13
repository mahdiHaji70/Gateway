using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.NationalId)
                .HasMaxLength(20);

            builder.Property(x => x.Mobile)
                .HasMaxLength(11);

            builder.Property(x => x.Address)
                .HasMaxLength(500);

            builder.Property(x => x.PostCode)
                .HasMaxLength(10);
        }
    }
}
