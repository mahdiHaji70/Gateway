using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ContainerConfiguration : IEntityTypeConfiguration<Container>
    {
        public void Configure(EntityTypeBuilder<Container> builder)
        {
            builder.ToTable("Containers", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.No)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(c => c.ContainerTypeAndSize)
            .WithMany(cn => cn.Containers)
            .HasForeignKey(c => c.ContainerTypeAndSizeId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
