using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Models;
using LivingLab.Web.ApiModels;
using LivingLab.Web.ViewModels;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to ViewModel/ApiModel
        CreateMap<Todo, TodoDTO>();
        CreateMap<EnergyUsageCsvModel, LogItemViewModel>();

        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();
        CreateMap<LogItemViewModel, EnergyUsageCsvModel>();
    }
}
