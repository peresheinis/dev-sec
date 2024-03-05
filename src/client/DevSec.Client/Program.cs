using DevSec.Client.Application;
using DevSec.Client.Application.Services;
using DevSec.Client.Endpoints;
using DevSec.Client.Infrastructure;
using DevSec.Client.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDevicesService, DevicesService>();

builder.Services.AddMediator();
builder.Services.AddDatabase();
builder.Services.EnableAnnotations();
builder.Services.AddRecordingManager();

builder.Services.AddAutoMapper(configuration =>
{
    configuration.AddProfile<DevicesProfile>();
});

var app = builder.Build();

app.UseRouting();

app.UseAuthorization();

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Devices V1"));

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.Services
    .CreateScope().ServiceProvider
    .GetRequiredService<DatabaseContext>().Database
    .MigrateAsync();

await app.RunAsync();
