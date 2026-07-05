using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class DictionaryWordConfiguration
    : IEntityTypeConfiguration<DictionaryWordEntity>
{
    public void Configure(EntityTypeBuilder<DictionaryWordEntity> builder)
    {
        builder.ToTable("DictionaryWords");

        builder.HasKey(x => new
        {
            x.DictionaryId,
            x.WordId
        });

        builder
            .HasOne(x => x.Dictionary)
            .WithMany(x => x.DictionaryWords)
            .HasForeignKey(x => x.DictionaryId);

        builder
            .HasOne(x => x.Word)
            .WithMany(x => x.DictionaryWords)
            .HasForeignKey(x => x.WordId);
    }
}