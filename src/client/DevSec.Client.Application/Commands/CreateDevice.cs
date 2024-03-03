using AutoMapper;
using DevSec.Client.Core;
using DevSec.Client.Core.Entities;
using DevSec.Client.Core.Repositories;
using DevSec.Client.Shared;
using MediatR;

namespace DevSec.Client.Commands;

public static class CreateDevice
{
    public record Request(
        string Name, 
        DeviceVideoDTO Video,
        DeviceSoundDTO? Sound,
        DeviceLocationDTO? Location,
        DeviceIconColorDTO? Color,
        DeviceConfigurationDTO? Configuration) : IRequest<DeviceDTO>;

    internal class RequestHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IDeviceRepository deviceRepository) : IRequestHandler<Request, DeviceDTO>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public async Task<DeviceDTO> Handle(Request request, CancellationToken cancellationToken)
        {
            var device = new Device(
                request.Name,
                _mapper.Map<DeviceVideo>(request.Video),
                _mapper.Map<DeviceConfiguration>(request.Configuration),
                _mapper.Map<DeviceIconColor>(request.Color),
                _mapper.Map<DeviceSound>(request.Sound), null,
                _mapper.Map<DeviceLocation>(request.Location));
            
            await _deviceRepository.AddAsync(device, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DeviceDTO>(device);
        }
    }
}
