using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    internal abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : EntityBase
    {
        protected abstract void Configure(EntityTypeBuilder<T> builder);

        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);
            builder.HasKey(t => t.Id);
            Configure(builder);
        }
    }
}