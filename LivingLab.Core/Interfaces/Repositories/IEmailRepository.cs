using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public interface IEmailRepository
{
    Task<List<EmailLog>> GetEmailByStatus(string status);
    Task<List<EmailLog>> GetEmailByDateRange(DateTime start, DateTime end);
}
