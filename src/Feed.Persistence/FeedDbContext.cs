using Feed.Persistence.Configurations;
using Feed.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Feed.Persistence;

public sealed class FeedDbContext(DbContextOptions<FeedDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}