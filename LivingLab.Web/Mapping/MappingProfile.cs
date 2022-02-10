using AutoMapper;

using LivingLab.Domain.Entities;
using LivingLab.Web.ApiModels;

namespace LivingLab.Web.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to ViewModel/ApiModel
        CreateMap<Todo, TodoDTO>();

        // ViewModel/ApiModel to Domain
        CreateMap<TodoDTO, Todo>();
    }
}
