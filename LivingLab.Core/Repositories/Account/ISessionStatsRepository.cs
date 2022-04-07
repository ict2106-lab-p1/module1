using LivingLab.Core.Entities;

namespace LivingLab.Core.Repositories.Account;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ISessionStatsRepository : IRepository<SessionStats>
{
    Task<List<SessionStats>> GetSessionStatsView(string labLocation);

    void LogFileUpload(int labId, double fileSize);
}
