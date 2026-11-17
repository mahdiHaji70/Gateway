using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class DocumentSerialCounterConfiguration : IEntityTypeConfiguration<DocumentSerialCounter>
    {
        public void Configure(EntityTypeBuilder<DocumentSerialCounter> builder)
        {
            builder.ToTable("DocumentSerialCounters", schema: "doc");

            builder.HasKey(x => new { x.SerialType, x.TerminalCode, x.JalaliYear });

            builder.Property(x => x.SerialType)
                .HasConversion(new ValueConverter<DocumentSerialType, string>(
                    serialType => DocumentSerialTypeCode.ToCode(serialType),
                    code => DocumentSerialTypeCode.FromCode(code)))
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.TerminalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.JalaliYear)
                .IsRequired();

            builder.Property(x => x.LastCounter)
                .IsRequired();

            builder.Property(x => x.RowVersion)
                .IsRowVersion();
        }
    }
}
