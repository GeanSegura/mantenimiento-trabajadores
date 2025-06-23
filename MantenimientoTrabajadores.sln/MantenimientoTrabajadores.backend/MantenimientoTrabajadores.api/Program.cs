using MantenimientoTrabajadores.api.Entity;
using MantenimientoTrabajadores.api.Models;
using MantenimientoTrabajadores.api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUbigeoService, UbigeoService>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddDbContext<ApplicationDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("OurHeroConnectionString")), ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
