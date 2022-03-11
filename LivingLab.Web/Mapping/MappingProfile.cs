using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
<<<<<<< HEAD
using LivingLab.Core.Models;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels;
=======
using LivingLab.Web.Models.DTOs.Todo;
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to ViewModel/ApiModel
        CreateMap<Todo, TodoDTO>();
        CreateMap<EnergyUsageCsvModel, LogItemViewModel>();
        CreateMap<EnergyUsageLog, LogItemViewModel>();
        CreateMap<Device, DeviceViewModel>();
        CreateMap<Accessory, AccessoryViewModel>();
        CreateMap<ViewDeviceTypeDTO, DeviceTypeViewModel>();
        CreateMap<ViewAccessoryTypeDTO, AccessoryTypeViewModel>();
        
        
        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();
<<<<<<< HEAD
        CreateMap<LogItemViewModel, EnergyUsageCsvModel>();
        CreateMap<LogItemViewModel, EnergyUsageLog>()
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { SerialNo = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));
        CreateMap<DeviceViewModel, Device>();
        CreateMap<AccessoryViewModel, Accessory>();
=======

        //// Domain to ViewModel/ApiModel
        //CreateMap<List<Device>, List<DeviceViewModel>>();

        //// ViewModel/ApiModel to Domain
        //CreateMap<List<DeviceViewModel>, List<Device>>();

        // Domain to ViewModel/ApiModel
        CreateMap<Device, DeviceViewModel>();

        // ViewModel/ApiModel to Domain
        CreateMap<DeviceViewModel, Device>();

        // Domain to ViewModel/ApiModel (Accessory)
        CreateMap<Accessory, AccessoryViewModel>();

        // ViewModel/ApiModel to Domain (Accessory)
        CreateMap<AccessoryViewModel, Accessory>();

        CreateMap<ViewDeviceTypeDTO, DeviceTypeViewModel>();
        
        CreateMap<ViewAccessoryTypeDTO, AccessoryTypeViewModel>();
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    }
}
