using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Data.Mappings
{
    internal class BiddingConfiguration : EntityTypeConfiguration<Bidding>
    {
        protected override void Configure(EntityTypeBuilder<Bidding> builder)
        {
            builder.Property(e => e.Status)
                .HasConversion(v => v.ToString(), v => (BiddingStatusEnum)Enum.Parse(typeof(BiddingStatusEnum), v));

            builder.Property(p => p.Description)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(p => p.Number)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
