using Ardalis.ApiEndpoints;
using DevSec.Client.Application.Queries;
using DevSec.Client.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSec.Client.Endpoints.Devices;


public class GetPhysicalDevicesEndpoint(ISender sender) : EndpointBaseAsync
    .WithoutRequest
    .WithResult<IReadOnlyCollection<CaptureDeviceDTO>>
{
    private readonly ISender _sender = sender;

    [SwaggerOperation(
        Summary = "Get all physical connected devies",
        Description = "Get all physical connected devies",
        OperationId = "Device_GetPhysical",
        Tags = ["DevicesEndpoint"])]
    [HttpGet("api/devices/physical")]
    public override Task<IReadOnlyCollection<CaptureDeviceDTO>> HandleAsync(
        CancellationToken cancellationToken = default) =>
        _sender.Send(new GetPhysicalDevices.Query(), cancellationToken);
}