using Feed.Persistence.Configurations;
using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence;

internal sealed class FeedDbContext(DbContextOptions<FeedDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DictionaryEntity> Dictionaries { get; set; }
    public DbSet<WordEntity> Words { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new DictionaryConfiguration());
        modelBuilder.ApplyConfiguration(new WordConfiguration());
        modelBuilder.ApplyConfiguration(new DictionaryWordConfiguration());
    }
}
