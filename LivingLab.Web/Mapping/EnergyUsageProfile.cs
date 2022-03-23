using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Models;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageProfile : Profile
{
    public EnergyUsageProfile()
    {
        CreateMap<EnergyUsageCsvModel, LogItemViewModel>().ReverseMap();
        CreateMap<EnergyUsageFilterDTO, EnergyUsageFilterViewModel>().ReverseMap();
        CreateMap<EnergyUsageDTO, EnergyUsageViewModel>().ReverseMap();
        CreateMap<EnergyBenchmarkDTO, EnergyBenchmarkViewModel>().ReverseMap();
        
        CreateMap<EnergyUsageLog, LogItemViewModel>();
        CreateMap<LogItemViewModel, EnergyUsageLog>()
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { SerialNo = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));
    }
}
