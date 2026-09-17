  using Scalar.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Api_BoxCenter.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



// configuracion de base de datos
builder.Services.AddDbContext<BoxCenterDbContext>( options => {
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});



builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    // implementar scalar
    app.MapScalarApiReference();
}

//app.MapGet("/", () => "hola que tal, tu como estas.");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
