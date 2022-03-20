using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<Device, DeviceViewModel>().ReverseMap();
        CreateMap<ViewDeviceTypeDTO, DeviceTypeViewModel>().ReverseMap();
    }
}
