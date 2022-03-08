using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Models;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to ViewModel/ApiModel
        CreateMap<Todo, TodoDTO>();
        CreateMap<EnergyUsageCsvModel, LogItemViewModel>();
        CreateMap<EnergyUsageLog, LogItemViewModel>();

        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();
        CreateMap<LogItemViewModel, EnergyUsageCsvModel>();
        CreateMap<LogItemViewModel, EnergyUsageLog>()
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { DeviceSerialNumber = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));
    }
}
