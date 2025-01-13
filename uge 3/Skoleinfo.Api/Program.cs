using Microsoft.EntityFrameworkCore;
using Skoleinfo.Api.Models;
using Microsoft.OpenApi.Models;
using Skoleinfo.Api.Endpoints;
using Skoleinfo.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Register the DbContext with the dependency injection container
builder.Services.AddDbContext<SkoleinfoContext>(options =>
    options.UseSqlServer(connectionString));

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skoleinfo API", Version = "v1" });
});

builder.Services.AddScoped(typeof(ISkoleinfoRepository<>), typeof(SkoleinfoRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Skoleinfo API v1");
        c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseHttpsRedirection();

app.MapSkoleinfoEndpoints();

app.Run();