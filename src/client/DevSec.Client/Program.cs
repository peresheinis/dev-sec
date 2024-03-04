using DevSec.Client.Application;
using DevSec.Client.Application.Queries;
using DevSec.Client.Application.Services;
using DevSec.Client.Core;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Endpoints;
using DevSec.Client.Infrastructure;
using DevSec.Client.Infrastructure.Repositories;
using DevSec.Client.Profiles;
using MicroEndpoints.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDevicesService, DevicesService>();

builder.Services.AddMediator();
builder.Services.AddDatabase();
builder.Services.AddMicroEndpoints();


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
