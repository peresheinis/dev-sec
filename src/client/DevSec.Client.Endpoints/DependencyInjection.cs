using MicroEndpoints.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Endpoints;

public static class DependencyInjection
{
    public static IServiceCollection AddMicroEndpoints(this IServiceCollection serviceDescriptors) =>
        serviceDescriptors.AddMicroEndpoints(typeof(DependencyInjection).Assembly);
}
