using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    internal abstract class EntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : EntityBase<T>
    {
        protected abstract void Configure(EntityTypeBuilder<T> builder);

        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name);
            builder.HasKey(t => t.Id);
            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ClassLevelCascadeMode);
            builder.Ignore(c => c.RuleLevelCascadeMode);
            Configure(builder);
        }
    }
}