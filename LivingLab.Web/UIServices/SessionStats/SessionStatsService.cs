using AutoMapper;

using LivingLab.Core.DomainServices.Account.Session;
using LivingLab.Web.Models.ViewModels.SessionStats;

namespace LivingLab.Web.UIServices.SessionStats;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class SessionStatsService : ISessionStatsService
{
    private readonly IMapper _mapper;
    private readonly ISessionStatsDomainService _sessionStatsDomainService;

    public SessionStatsService(ISessionStatsDomainService sessionStatsService, IMapper mapper)
    {
        _sessionStatsDomainService = sessionStatsService;
        _mapper = mapper;
    }

    /// <summary>
    /// View session statistics by lab location
    /// </summary>
    /// <param name="labLocation">Lab Location</param>
    /// <returns>List of Session Statistics from ViewSessionStatsViewModel</returns>
    public async Task<ViewSessionStatsViewModel> ViewSessionStats(string labLocation)
    {
        //retrieve data from db
        List<Core.Entities.SessionStats> sessionStatsList =
            await _sessionStatsDomainService.ViewSessionStats(labLocation);

        //map entity model to view model
        List<SessionStatsViewModel> sessionstats =
            _mapper.Map<List<Core.Entities.SessionStats>, List<SessionStatsViewModel>>(sessionStatsList);

        //add list of sessionStats view model to the view sessionStats view model
        return new ViewSessionStatsViewModel { SessionStatsList = sessionstats };
    }
}
