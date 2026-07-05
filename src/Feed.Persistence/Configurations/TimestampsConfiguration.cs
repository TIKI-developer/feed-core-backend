using Feed.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

public static class TimestampsConfiguration
{
    public static void Configure<T>(
        this OwnedNavigationBuilder<T, Timestamps> builder)
        where T : class
    {
        builder.Property(t => t.CreatedAt)
            .HasField("_createdAt")
            .HasColumnName("CreatedAt")
            .IsRequired();

        builder.Property(t => t.UpdatedAt)
            .HasField("_updatedAt")
            .HasColumnName("UpdatedAt")
            .IsRequired();
    }
}