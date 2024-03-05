using AutoMapper;
using DevSec.Client.Core.Entities;
using DevSec.Client.Shared;
using Kernel.Shared.Extensions;

namespace DevSec.Client.Profiles;

public class DevicesProfile : Profile
{
    public DevicesProfile() {
        this
            .CreateMap<PagedList<Device>, PagedList<DeviceDTO>>();

        this
            .CreateMap<SoundSourceDTO, SoundSource>()
            .ReverseMap();

        this
            .CreateMap<VideoSourceDTO, VideoSource>()
            .ReverseMap();

        this
            .CreateMap<DeviceLocationDTO, DeviceLocation>()
            .ReverseMap();

        this
            .CreateMap<DeviceIconColorDTO, DeviceIconColor>()
            .ReverseMap();

        this
            .CreateMap<DeviceConfigurationDTO, DeviceConfiguration>()
            .ReverseMap();

        this
            .CreateMap<DeviceVideoDTO, DeviceVideo>()
            .ReverseMap();

        this
            .CreateMap<VideoConfigurationDTO, VideoConfiguration>()
            .ReverseMap();

        this
            .CreateMap<DeviceSoundDTO, DeviceSound>()
            .ReverseMap();

        this
            .CreateMap<Device, DeviceDTO>()
            .ReverseMap();
    }
}
