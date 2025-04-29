using Microsoft.EntityFrameworkCore;
using sensores.Models;
using sensores.Repositories.LecturaRepository;
using sensores.Repositories.SensorRepository;
using sensores.Repositories.UbicacionRepository;
using sensores.Services.LecturaService;
using sensores.Services.SensorService;
using sensores.Services.UbicacionService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SensoresContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));

builder.Services.AddScoped<ISensorRepository, SensorRepository>();
builder.Services.AddScoped<ISensorService, SensorService>();

builder.Services.AddScoped<IUbicacionRepository, UbicacionRepository>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();

builder.Services.AddScoped<ILecturaRepository, LecturaRepository>();
builder.Services.AddScoped<ILecturaService, LecturaService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Custom",
        policy =>
        {
            policy.WithOrigins("https://localhost:7236")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

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

app.UseCors("Custom");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
