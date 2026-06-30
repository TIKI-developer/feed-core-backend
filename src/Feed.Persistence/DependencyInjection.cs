using Feed.Application.Interfaces;
using Feed.Persistence.Interfaces;
using Feed.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");

        services.AddDbContext<FeedDbContext>(options =>
        {
            options.UseNpgsql(connectionString, o =>
            {
                o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });
        });

        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}