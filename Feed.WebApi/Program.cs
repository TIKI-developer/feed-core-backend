var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddHttpContextAccessor()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.MapControllers();

app.Run();