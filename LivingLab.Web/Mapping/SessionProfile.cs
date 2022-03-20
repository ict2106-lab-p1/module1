using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.SessionStats;

namespace LivingLab.Web.Mapping;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class SessionProfile : Profile
{
    public SessionProfile()
    {
        CreateMap<SessionStats, SessionStatsViewModel>().ReverseMap();
    }
}
