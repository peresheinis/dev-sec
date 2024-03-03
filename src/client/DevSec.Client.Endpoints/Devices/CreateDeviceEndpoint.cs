using DevSec.Client.Commands;
using DevSec.Client.Shared;
using MediatR;
using MicroEndpoints.Attributes;
using MicroEndpoints.FluentGenerics;
using Microsoft.AspNetCore.Mvc;

namespace DevSec.Client.Endpoints.Devices;

public sealed class CreateDeviceEndpoint(ISender sender) : EndpointBaseAsync
    .WithRequest<CreateDevice.Request>
    .WithResult<DeviceDTO>
{
    private readonly ISender _sender = sender;

    [Post("api/devices")]
    public override Task<DeviceDTO> HandleAsync(
        [FromServices] IServiceProvider serviceProvider,
        CreateDevice.Request request,
        CancellationToken cancellationToken = default) =>
        _sender.Send(request, cancellationToken);
}