using Feed.Application.Interfaces;
using Feed.Email.Options;
using Feed.Email.Templates;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Feed.Email;

public static class DependencyInjection
{
    public static IServiceCollection AddEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailService, SmtpEmailService>();
        services.AddSingleton<EmbeddedResourceProvider>();
        services.AddSingleton<EmailTemplateRenderer>();
        services.Configure<EmailProviderOptions>(options =>
        configuration.GetSection(nameof(EmailProviderOptions)).Bind(options));

        return services;
    }
}
