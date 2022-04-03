using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Notification;

namespace LivingLab.Infrastructure.Repositories.Notification;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class SmsRepository : ISmsRepository
{
    public Task<List<SmsLog>> GetSmsByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public Task<List<SmsLog>> GetSmsByDateRange(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}
