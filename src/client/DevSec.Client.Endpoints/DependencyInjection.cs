using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DevSec.Client.Endpoints;

public static class DependencyInjection
{
    public static IServiceCollection EnableAnnotations(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.UseNamespaceRouteToken();
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressInferBindingSourcesForParameters = true;
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Devices", Version = "v1" });
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Devices.xml"));
        });

        return services;
    }
}
