using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class DictionaryConfiguration : IEntityTypeConfiguration<DictionaryEntity>
{
    public void Configure(EntityTypeBuilder<DictionaryEntity> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .OwnsOne(rt => rt.Timestamps, ts =>
            {
                ts.Configure();
            });
    }
}
