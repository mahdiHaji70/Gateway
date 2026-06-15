using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class DeclarationContainerGoodConfiguration : IEntityTypeConfiguration<DeclarationContainerGood>
    {
        public void Configure(EntityTypeBuilder<DeclarationContainerGood> builder)
        {
            builder.ToTable("DeclarationContainerGoods", schema: "doc");

            builder.HasKey(x => x.Id);            

            builder.HasOne(c => c.DeclarationContainer)
            .WithMany(cn => cn.DeclarationContainerGoods)
            .HasForeignKey(c => c.DeclarationContainerId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Commodity)
            .WithMany(cn => cn.CommodityDeclarationContainerGoods)
            .HasForeignKey(c => c.CommodityId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Package)
           .WithMany(cn => cn.PackageDeclarationContainerGoods)
           .HasForeignKey(c => c.PackageId)
           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
