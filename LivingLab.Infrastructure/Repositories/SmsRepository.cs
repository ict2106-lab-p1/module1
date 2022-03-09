using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;

namespace LivingLab.Infrastructure.Repositories;

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
