using DevSec.Client.Application.Queries;
using DevSec.Client.Shared;
using MediatR;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using Microsoft.AspNetCore.Mvc;

namespace DevSec.Client.Endpoints.Devices;

public sealed class GetCaptureDevicesEndpoint(ISender sender) : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IReadOnlyCollection<CaptureDeviceDTO>>
{
    private readonly ISender _sender = sender;

    [Get("api/devices/capture")]
    public override Task<IReadOnlyCollection<CaptureDeviceDTO>> HandleAsync(
        [FromServices] IServiceProvider serviceProvider, 
        CancellationToken cancellationToken = default) =>
        _sender.Send(new GetCaptureDevices.Query());
}
