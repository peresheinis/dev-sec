using Ardalis.ApiEndpoints;
using DevSec.Client.Commands;
using DevSec.Client.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSec.Client.Endpoints.Devices;

public class CreateDeviceEndpoint(ISender sender) : EndpointBaseAsync
    .WithRequest<CreateDevice.Request>
    .WithResult<DeviceDTO>
{
    private readonly ISender _sender = sender;

    [HttpPost("api/devices")]
    [SwaggerOperation(
        Summary = "Creates a new Device",
        Description = "Creates a new Device",
        OperationId = "Device_Create",
        Tags = ["DevicesEndpoint"])]
    public override Task<DeviceDTO> HandleAsync(
        CreateDevice.Request request,
        CancellationToken cancellationToken = default) =>
        _sender.Send(request, cancellationToken);
}