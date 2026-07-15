using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class WordConfiguration : IEntityTypeConfiguration<WordEntity>
{
    public void Configure(EntityTypeBuilder<WordEntity> builder)
    {
        builder
            .HasKey(e => e.Id);
    }
}
