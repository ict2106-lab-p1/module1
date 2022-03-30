using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.Mapping;

public class LabProfile : Profile
{
    public LabProfile()
    {
        CreateMap<Lab, EnergyUsageLabViewModel>().ReverseMap();
        CreateMap<Lab, LabProfileViewModel>().ReverseMap();
        CreateMap<Lab, LabViewModel>().ReverseMap();
    }
}
