using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Models;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.SessionStats;
using LivingLab.Web.Models.ViewModels.Login;

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
        CreateMap<SessionStats, SessionStatsViewModel>();
        CreateMap<ViewDeviceTypeDTO, DeviceTypeViewModel>();
        CreateMap<ViewAccessoryTypeDTO, OverallAccessoryTypeViewModel>();
        CreateMap<AccessoryType, AccessoryTypeViewModel>();
        CreateMap<AccessoryDetailsDTO, AccessoryDetailsViewModel>();
        CreateMap<ViewAccessoryTypeDTO, AccessoryTypeViewModel>();
        CreateMap<ViewDeviceTypeDTO, DeviceTypeViewModel>();
        
        


        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();
        CreateMap<LogItemViewModel, EnergyUsageCsvModel>();
        CreateMap<LogItemViewModel, EnergyUsageLog>()
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { SerialNo = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));
        CreateMap<DeviceViewModel, Device>();
        CreateMap<AccessoryViewModel, Accessory>();
        CreateMap<AccessoryTypeViewModel, ViewAccessoryTypeDTO>();
        CreateMap<AccessoryDetailsViewModel, AccessoryDetailsDTO>();
    }
}
