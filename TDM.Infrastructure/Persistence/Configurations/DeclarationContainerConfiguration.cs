using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class DeclarationContainerConfiguration : IEntityTypeConfiguration<DeclarationContainer>
    {
        public void Configure(EntityTypeBuilder<DeclarationContainer> builder)
        {
            builder.ToTable("DeclarationContainers", schema: "doc");

            builder.HasKey(x => x.Id);            

            builder.HasOne(c => c.DeclarationItem)
            .WithMany(cn => cn.DeclarationContainers)
            .HasForeignKey(c => c.DeclarationItemId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
