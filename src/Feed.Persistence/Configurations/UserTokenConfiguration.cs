using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal sealed class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenEntity>
{
    public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
    {
        builder
            .HasKey(t => t.Id);
        builder
            .Property(t => t.TokenHash)
            .HasMaxLength(32)
            .IsRequired();
        builder
            .Property(t => t.Purpose)
            .HasConversion<string>()
            .HasMaxLength(128)
            .IsRequired();
        builder
            .Property(t => t.ExpiredAt)
            .IsRequired();
        builder
            .HasIndex(t => t.TokenHash)
            .IsUnique();
        builder
            .HasIndex(t => t.UserId);
    }
}
