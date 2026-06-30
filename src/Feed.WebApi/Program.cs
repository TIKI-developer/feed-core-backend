using Feed.Application;
using Feed.Persistence;
using Feed.Persistence.Interfaces;
using Feed.Security;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddSecurity(builder.Configuration);

builder
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddHttpContextAccessor()
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

app.MapControllers();

app.Run();
