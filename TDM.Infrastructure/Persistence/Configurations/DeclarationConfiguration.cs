using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class DeclarationConfiguration : IEntityTypeConfiguration<Declaration>
    {
        public void Configure(EntityTypeBuilder<Declaration> builder)
        {
            builder.ToTable("Declarations", schema: "doc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(50);            

            builder.HasOne(c => c.Consignee)
            .WithMany(cn => cn.ConsigneeDeclarations)
            .HasForeignKey(c => c.ConsigneeId)
            .OnDelete(DeleteBehavior.Restrict);

             builder.HasOne(c => c.ConsigneeRep)
            .WithMany(cn => cn.ConsigneeRepDeclarations)
            .HasForeignKey(c => c.ConsigneeRepId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
