using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Models;
using LivingLab.Web.Models.DTOs.Todo;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.SessionStats;

using Lab = LivingLab.Core.Entities.Lab;
using LabViewModel = LivingLab.Web.Models.ViewModels.LabViewModel;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoDTO>().ReverseMap();
        CreateMap<Lab, LabViewModel>().ReverseMap();
    }
}
