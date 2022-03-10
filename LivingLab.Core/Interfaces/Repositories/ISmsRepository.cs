using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface ISmsRepository
{
    Task<List<SmsLog>> GetSmsByStatus(string status);
    Task<List<SmsLog>> GetSmsByDateRange(DateTime start, DateTime end);
}
