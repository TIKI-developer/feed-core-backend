using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Roles");
        builder.HasKey(r => r.Name);
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .HasMany(r => r.Permissions)
            .WithOne()
            .HasForeignKey(p => p.Name);
    }
}
