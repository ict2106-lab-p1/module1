using AutoMapper;

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
    }
}
