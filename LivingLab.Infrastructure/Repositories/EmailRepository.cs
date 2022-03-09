using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;

namespace LivingLab.Infrastructure.Repositories;

public class EmailRepository : IEmailRepository
{
    public Task<List<EmailLog>> GetEmailByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmailLog>> GetEmailByDateRange(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}
