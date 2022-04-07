using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.Account.Session;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ISessionStatsDomainService
{
    Task<List<SessionStats>> ViewSessionStats(string labLocation);
}
