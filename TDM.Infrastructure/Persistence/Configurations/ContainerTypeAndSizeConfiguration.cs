using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class ContainerTypeAndSizeConfiguration : IEntityTypeConfiguration<ContainerTypeAndSize>
    {
        public void Configure(EntityTypeBuilder<ContainerTypeAndSize> builder)
        {
            builder.ToTable("ContainerTypesAndSizes", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TypeAndSize)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TypeAndSizeCode)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
