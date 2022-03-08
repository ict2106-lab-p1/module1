using AutoMapper;

using LivingLab.Web.ViewModels;
using LivingLab.Core.Entities;
using LivingLab.Web.Models.DTOs.Todo;

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

        // Domain to ViewModel/ApiModel (Accessory)
        CreateMap<Accessory, AccessoryViewModel>();

        // ViewModel/ApiModel to Domain (Accessory)
        CreateMap<AccessoryViewModel, Accessory>();
    }
}
