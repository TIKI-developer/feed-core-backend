using Feed.Persistence.Configurations;
using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence;

internal sealed class FeedDbContext(DbContextOptions<FeedDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<PermissionEntity> Permissions { get; set; }
    public DbSet<PublicationEntity> Publications { get; set; }
    public DbSet<UserTokenEntity> ConfirmationTokens { get; set; }
    public DbSet<DictionaryEntity> Dictionaries { get; set; }
    public DbSet<WordEntity> Words { get; set; }
    public DbSet<SourceEntity> Sources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        modelBuilder.ApplyConfiguration(new DictionaryConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
        modelBuilder.ApplyConfiguration(new DictionaryWordConfiguration());
        modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        modelBuilder.ApplyConfiguration(new SourceConfiguration());
        modelBuilder.ApplyConfiguration(new PublicationConfiguration());
    }
}
