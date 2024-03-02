using DevSec.Client.Commands;
using DevSec.Client.Core.Entities;
using DevSec.Client.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using DevSec.Client.Extensions;
using AutoMapper;
using AForge.Video.DirectShow;
using DevSec.Client.Services;

namespace DevSec.Client.Controllers;

[Route("[controller]")]
public class DevicesController : ControllerBase
{
    [HttpGet]
    public Task<IPagedList<Device>> GetDevices(
        int page,
        int pageSize,
        [FromServices] IDeviceRepository deviceRepository,
        CancellationToken cancellationToken = default) =>
        deviceRepository.GetAsync(page, pageSize, cancellationToken);

    [HttpPost]
    public Task<Device> CreateDevice(
        CreateDevice.Request request,
        [FromServices] ISender sender,
        CancellationToken cancellationToken = default) =>
        sender.Send(request, cancellationToken);

    [HttpGet("CaptureDevices")]
    public Task<IReadOnlyCollection<FilterInfo>> GetCaptureDevices(
        [FromServices] IDevicesService devicesService,
        CancellationToken cancellationToken = default) =>
        Task.FromResult(devicesService.GetVideoDevices());
}
