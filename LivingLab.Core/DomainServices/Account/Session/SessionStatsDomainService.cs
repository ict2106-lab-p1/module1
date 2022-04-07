using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Account;

namespace LivingLab.Core.DomainServices.Account.Session;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class SessionStatsDomainService : ISessionStatsDomainService
{
    private readonly ISessionStatsRepository _sessionStatsRepository;

    public SessionStatsDomainService(ISessionStatsRepository sessionStatsRepository)
    {
        _sessionStatsRepository = sessionStatsRepository;
    }

    /// <summary>
    /// This function calls SessionStatsRepository to retrieve a list of SessionStats of each lab.
    /// </summary>
    /// <param name="labLocation">lab's location</param>
    /// <returns>a list of session stats</returns>
    public Task<List<SessionStats>> ViewSessionStats(string labLocation)
    {
        return _sessionStatsRepository.GetSessionStatsView(labLocation);
    }

}
