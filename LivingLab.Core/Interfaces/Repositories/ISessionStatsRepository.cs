using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ISessionStatsRepository : IRepository<SessionStats>
{
    Task<List<SessionStats>> GetSessionStatsView(string labLocation);
    
    void LogFileUpload(string labId, double fileSize);
}
