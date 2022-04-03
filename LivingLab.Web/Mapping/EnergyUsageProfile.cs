using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Web.Models.DTOs;
using LivingLab.Web.Models.ViewModels.EnergyUsage;

using Lab = LivingLab.Core.Entities.Lab;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageProfile : Profile
{
    public EnergyUsageProfile()
    {
        CreateMap<EnergyUsageCsvDTO, LogItemViewModel>().ReverseMap();
        CreateMap<EnergyUsageFilterDTO, EnergyUsageFilterViewModel>().ReverseMap();
        CreateMap<Lab, EnergyBenchmarkViewModel>().ReverseMap();
        CreateMap<LabDetailsDTO, EnergyBenchmarkViewModel>().ReverseMap();
        CreateMap<EnergyUsageLog, EnergyUsageLogViewModel>().ReverseMap();
        CreateMap<EnergyUsageDTO, EnergyUsageViewModel>().ReverseMap();

        CreateMap<EnergyUsageLog, EnergyUsageLogDTO>().ReverseMap()
            .ForMember(dest => dest.Lab,
                opt => opt.MapFrom(src => new Lab { LabLocation = src.LabLocation }))
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { SerialNo = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));

        CreateMap<EnergyUsageLog, LogItemViewModel>().ReverseMap()
            .ForMember(dest => dest.Lab,
                opt => opt.MapFrom(src => new Lab { LabLocation = src.LabLocation }))
            .ForMember(dest => dest.Device,
                opt => opt.MapFrom(src => new Device { SerialNo = src.DeviceSerialNo }))
            .ForMember(dest => dest.Interval,
                opt => opt.MapFrom(src => TimeSpan.FromMinutes(src.Interval)));
    }
    class TimeSpanConverter : ITypeConverter<TimeSpan, double>
    {
        public double Convert(TimeSpan source, double destination, ResolutionContext context)
        {
            return source.Minutes;
        }
    }
}
