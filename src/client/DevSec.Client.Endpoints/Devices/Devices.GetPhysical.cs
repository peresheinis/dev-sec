using DevSec.Client.Application.Queries;
using DevSec.Client.Shared;
using MediatR;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevSec.Client.Endpoints.Devices;

public static partial class Devices
{
    public class GetPhysical : EndpointBaseAsync
        .WithoutRequest
        .WithResult<IReadOnlyCollection<CaptureDeviceDTO>>
    {
        [Get("api/devices/physical")]
        public override Task<IReadOnlyCollection<CaptureDeviceDTO>> HandleAsync(
            [FromServices] IServiceProvider serviceProvider, CancellationToken cancellationToken = default) =>
            serviceProvider
                .GetRequiredService<ISender>()
                .Send(new GetPhysicalDevices.Query(), cancellationToken);
    }
}
