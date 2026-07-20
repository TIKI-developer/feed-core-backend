using Feed.Application.Interfaces.Repositories;
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
        var connectionString = configuration.GetConnectionString("PostgresDbConnection");

        services.AddDbContext<FeedDbContext>(options =>
        {
            options.UseNpgsql(connectionString, o =>
            {
                o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
            });
        });

        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDictionaryRepository, DictionaryRepository>();
        services.AddScoped<IUserTokenRepository, UserTokenRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IWordRepository, WordRepository>();
        services.AddScoped<ISourceRepository, SourceRepository>();
        services.AddScoped<IPublicationRepository, PublicationRepository>();

        return services;
    }
}
