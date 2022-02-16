using AutoMapper;

using LivingLab.Domain.Entities;
using LivingLab.Web.ApiModels;
using LivingLab.Web.ViewModels;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to ViewModel/ApiModel
        CreateMap<Todo, TodoDTO>();

        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();

        //// Domain to ViewModel/ApiModel
        //CreateMap<List<Device>, List<DeviceViewModel>>();

        //// ViewModel/ApiModel to Domain
        //CreateMap<List<DeviceViewModel>, List<Device>>();

        // Domain to ViewModel/ApiModel
        CreateMap<Device, DeviceViewModel>();

        // ViewModel/ApiModel to Domain
        CreateMap<DeviceViewModel, Device>();
    }
}
