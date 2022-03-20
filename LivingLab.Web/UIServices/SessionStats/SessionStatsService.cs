using AutoMapper;

using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.SessionStats;

namespace LivingLab.Web.UIServices.SessionStats;

public class SessionStatsService : ISessionStatsService
{
    private readonly  IMapper _mapper;
    private readonly ISessionStatsDomainService _sessionStatsDomainService;

    public SessionStatsService(ISessionStatsDomainService sessionStatsService, IMapper mapper)
    {
        _sessionStatsDomainService = sessionStatsService;
        _mapper = mapper;
    }

    public async Task<ViewSessionStatsViewModel> ViewSessionStats()
    {
        //retrieve data from db
        List<Core.Entities.SessionStats> sessionStatsList = await _sessionStatsDomainService.ViewSessionStats();

        //map entity model to view model
        List<SessionStatsViewModel> sessionstats = _mapper.Map<List<Core.Entities.SessionStats>, List<SessionStatsViewModel>>(sessionStatsList);

        //add list of sessionStats view model to the view sessionStats view model
        return new ViewSessionStatsViewModel
        {
            SessionStatsList = sessionstats
        };
    }
}
