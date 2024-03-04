using DevSec.Client.Commands;
using DevSec.Client.Shared;
using MediatR;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Endpoints.Devices;

public static partial class Devices
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateDevice.Request>
        .WithResult<DeviceDTO>
    {
        [Post("api/devices")]
        public override Task<DeviceDTO> HandleAsync(
            [FromServices] IServiceProvider serviceProvider,
            CreateDevice.Request request, CancellationToken cancellationToken = default) =>
            serviceProvider
                .GetRequiredService<ISender>()
                .Send(request, cancellationToken);
    }
}

