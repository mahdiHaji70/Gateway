using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class DeclarationItemConfiguration : IEntityTypeConfiguration<DeclarationItem>
    {
        public void Configure(EntityTypeBuilder<DeclarationItem> builder)
        {
            builder.ToTable("DeclarationItems", schema: "doc");

            builder.HasKey(x => x.Id);            

            builder.HasOne(c => c.Declaration)
            .WithMany(cn => cn.DeclarationItems)
            .HasForeignKey(c => c.DeclarationId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Commodity)
            .WithMany(cn => cn.CommodityDeclarationItems)
            .HasForeignKey(c => c.CommodityId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Package)
            .WithMany(cn => cn.PackageDeclarationItems)
            .HasForeignKey(c => c.PackageId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
