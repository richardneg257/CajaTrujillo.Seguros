using CajaTrujillo.Seguros.Repository;
using CajaTrujillo.Seguros.Repository.Implementaciones;
using CajaTrujillo.Seguros.Repository.Interfaces;
using CajaTrujillo.Seguros.Service.Implementaciones;
using CajaTrujillo.Seguros.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CajaTrujilloDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CajaTrujilloConnection")));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<IPagosRepository, PagosRepository>();
builder.Services.AddScoped<IAfiliacionRepository, AfiliacionRepository>();
builder.Services.AddScoped<IAfiliacionService, AfiliacionService>();
builder.Services.AddScoped<IPagosService, PagosService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
