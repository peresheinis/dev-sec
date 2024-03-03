using DevSec.Client.Application.Queries;
using DevSec.Client.Application.Services;
using DevSec.Client.Core;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Endpoints.Devices;
using DevSec.Client.Infrastructure;
using DevSec.Client.Infrastructure.Repositories;
using DevSec.Client.Profiles;
using MicroEndpoints.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(GetCaptureDevices).Assembly));
builder.Services.AddMicroEndpoints(Assembly.GetAssembly(typeof(GetCaptureDevicesEndpoint)));
builder.Services.AddDbContext<DatabaseContext>(configuration => configuration.UseSqlite("Filename=database.db"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile<DevicesProfile>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMicroEndpoints();
app.UseAuthorization();

await app.Services
    .CreateScope().ServiceProvider
    .GetRequiredService<DatabaseContext>().Database
    .MigrateAsync();

await app.RunAsync();
