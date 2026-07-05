using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feed.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder
            .HasKey(x => x.Id);
        builder
            .OwnsOne(u => u.Email, email =>
            {
                email
                    .Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("Email");
                email
                    .HasIndex(e => e.Value)
                    .IsUnique();
            });

        builder
            .OwnsOne(u => u.Password, password =>
            {
                password
                    .Property(e => e.Hash)
                    .IsRequired()
                    .HasColumnName("PasswordHash");
            });
        builder
            .OwnsOne(u => u.FullName, fullName =>
            {
                fullName
                    .Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("FirstName");
                fullName
                    .Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("LastName");
                fullName
                    .Property(e => e.Patronymic)
                    .HasMaxLength(100)
                    .HasColumnName("Patronymic");
            });
    }
}
