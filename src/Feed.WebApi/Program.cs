using Feed.Application;
using Feed.Application.Interfaces;
using Feed.Email;
using Feed.Persistence;
using Feed.Persistence.Interfaces;
using Feed.Plugin.Host;
using Feed.Security;
using Feed.WebApi.Extensions;
using Feed.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddSecurity(builder.Configuration)
    .AddEmail(builder.Configuration)
    .AddPlugins(builder.Configuration);

builder
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApiAuthentication()
    .AddHttpContextAccessor()
    .AddScoped<IConfirmationUrlProvider, ConfirmationUrlProvider>()
    .AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var initializer = services.GetRequiredService<IDbInitializer>();

    await initializer.InitializeAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCustomExceptionHandler();
app.MapControllers();

app.Run();
