using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface ISmsRepository
{
    Task<List<SmsLog>> GetSmsByStatus(string status);
    Task<List<SmsLog>> GetSmsByDateRange(DateTime start, DateTime end);
}
