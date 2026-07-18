using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class SourceConfiguration : IEntityTypeConfiguration<SourceEntity>
{
        public void Configure(EntityTypeBuilder<SourceEntity> builder)
        {
        builder.ToTable("Sources");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ExternalId)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(e => e.SourceProviderName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.LastCheckedAt)
            .IsRequired();

        builder
            .OwnsOne(rt => rt.Timestamps, ts =>
            {
                ts.Configure();
            });

        builder.HasIndex(e => new
        {
            e.SourceProviderName,
            e.ExternalId
        }).IsUnique();
    }
}
