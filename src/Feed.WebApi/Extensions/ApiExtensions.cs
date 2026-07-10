using Feed.Security;
using Feed.WebApi.Constants;
using Feed.WebApi.Controllers;
using Feed.WebApi.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Feed.WebApi.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddApiAuthentication(this IServiceCollection services)
    {
        using var provider = services.BuildServiceProvider();
        var accessTokenOptions = provider.GetRequiredService<IOptions<AccessTokenOptions>>().Value;

        if (string.IsNullOrEmpty(accessTokenOptions.JwtOptions.SecretKey))
        {
            throw new InvalidOperationException("SecretKey not found");
        }

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding
                        .UTF8
                        .GetBytes
                        (
                            accessTokenOptions
                                .JwtOptions
                                .SecretKey
                        )
                    )
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies[Cookies.ACCESS_TOKEN_NAME];
                    return Task.CompletedTask;
                }
            };
        });
        services.AddScoped<ICurrentUser, CurrentUser>();

        return services;
    }
}