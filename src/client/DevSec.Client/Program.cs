using DevSec.Client.Core;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Infrastructure;
using DevSec.Client.Infrastructure.Repositories;
using DevSec.Client.Profiles;
using DevSec.Client.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
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


app.UseAuthorization();
app.MapControllers();


await app.Services
    .CreateScope().ServiceProvider
    .GetRequiredService<DatabaseContext>().Database
    .MigrateAsync();

await app.RunAsync();
