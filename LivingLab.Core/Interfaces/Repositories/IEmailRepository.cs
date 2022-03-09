using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IEmailRepository
{
    Task<List<EmailLog>> GetEmailByStatus(string status);
    Task<List<EmailLog>> GetEmailByDateRange(DateTime start, DateTime end);
}
