using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class PublicationConfiguration : IEntityTypeConfiguration<PublicationEntity>
{
    public void Configure(EntityTypeBuilder<PublicationEntity> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .Property(x => x.ExternalId)
            .IsRequired();
        builder
            .Property(x => x.Body)
            .IsRequired();
        builder
            .Property(x => x.PublishedAt)
            .IsRequired();
        builder
            .HasOne(e => e.Source)
            .WithMany()
            .HasForeignKey(e => e.SourceId);
        builder
            .OwnsOne(rt => rt.Timestamps, ts =>
            {
                ts.Configure();
            });
    }
}
