using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.EnergyUsage;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfile : Profile
{
    public LabProfile()
    {
        CreateMap<Lab, EnergyUsageLabViewModel>().ReverseMap();
        CreateMap<Lab, LabViewModel>().ReverseMap();
    }
}
