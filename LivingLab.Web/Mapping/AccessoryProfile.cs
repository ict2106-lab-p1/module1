using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Web.Models.ViewModels.Accessory;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryProfile : Profile
{
    public AccessoryProfile()
    {
        CreateMap<Accessory, AccessoryViewModel>().ReverseMap();
        CreateMap<AccessoryDetailsDTO, AccessoryDetailsViewModel>().ReverseMap();
        CreateMap<AccessoryType, AccessoryTypeViewModel>().ReverseMap();
        CreateMap<ViewAccessoryTypeDTO, AccessoryTypeViewModel>().ReverseMap();
        CreateMap<ViewAccessoryTypeDTO, OverallAccessoryTypeViewModel>().ReverseMap();
    }
}
