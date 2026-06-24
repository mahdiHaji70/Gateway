using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Configurations
{
    public class UserTerminalConfiguration : IEntityTypeConfiguration<UserTerminal>
    {
        public void Configure(EntityTypeBuilder<UserTerminal> builder)
        {
            builder.ToTable("UserTerminals", schema: "basicInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserNationalId)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(c => c.Terminal)
            .WithMany(cn => cn.UserTerminals)
            .HasForeignKey(c => c.TerminalId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
