using AutoMapper;
using DevSec.Client.Application.Notifications;
using DevSec.Client.Core;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Domain.Exceptions;
using DevSec.Client.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace DevSec.Client.Commands;

public static class UpdateDeviceStatus
{
    public class UpdateDeviceStatusApiRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; init; } = default!;

        [FromBody]
        public UpdateDeviceStatusRequest Request { get; init; } = default!;
    }

    public class UpdateDeviceStatusRequest
    { 
        public bool IsEnabled { get; set; }
    }

    public record Command(Guid Id, bool IsEnabled) : IRequest<DeviceDTO>;

    internal class RequestHandler(
        IMapper mapper,
        IPublisher publisher,
        IUnitOfWork unitOfWork,
        IDeviceRepository deviceRepository) : IRequestHandler<Command, DeviceDTO>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPublisher _publisher = publisher;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public async Task<DeviceDTO> Handle(Command request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetByIdAsync(request.Id);

            if (device is null)
            {
                throw DeviceErrors.NotFound(request.Id);
            }

            var changed = device.SetStatus(request.IsEnabled);

            var response = _mapper.Map<DeviceDTO>(device);

            if (!changed) return response;

            var notification = new DeviceStatusChangedEvent(
                device.Id,
                request.IsEnabled);

            await _unitOfWork
                .SaveChangesAsync(cancellationToken);

            await _publisher
                .Publish(notification, cancellationToken);

            return response;
        }
    }
}
