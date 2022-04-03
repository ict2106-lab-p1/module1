using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Account;

namespace LivingLab.Core.DomainServices.Account.Session;

public class SessionStatsDomainService : ISessionStatsDomainService
{
    private readonly ISessionStatsRepository _sessionStatsRepository;

    public SessionStatsDomainService(ISessionStatsRepository sessionStatsRepository)
    {
        _sessionStatsRepository = sessionStatsRepository;
    }
    
    
    public Task<List<SessionStats>> ViewSessionStats(string labLocation)
    {
        return _sessionStatsRepository.GetSessionStatsView(labLocation);
    }
    
}
