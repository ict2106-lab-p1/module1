using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Web.Models.DTOs.Todo;

namespace LivingLab.Web.Mapping;

/// <summary>
/// Please create a new profile class for each mapping!!
/// Should not need to touch this already :)
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoDTO>().ReverseMap();
    }
}
