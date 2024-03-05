using Ardalis.ApiEndpoints;
using DevSec.Client.Commands;
using DevSec.Client.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DevSec.Client.Endpoints.Devices;

public class UpdateDeviceStatusEndpoint(ISender sender) : EndpointBaseAsync
    .WithRequest<UpdateDeviceStatus.UpdateDeviceStatusApiRequest>
    .WithResult<DeviceDTO>
{
    private readonly ISender _sender = sender;

    [SwaggerOperation(
        Summary = "Update device status",
        Description = "Update device status",
        OperationId = "Device_UpdateStatus",
        Tags = ["DevicesEndpoint"])]

    [HttpPut("api/devices/{id:guid}/status")]
    public override Task<DeviceDTO> HandleAsync(
        UpdateDeviceStatus.UpdateDeviceStatusApiRequest request,
        CancellationToken cancellationToken = default) =>
        _sender.Send(new UpdateDeviceStatus.Command(request.Id, request.Request.IsEnabled), cancellationToken);
}