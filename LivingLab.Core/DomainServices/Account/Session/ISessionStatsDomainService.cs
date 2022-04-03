using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.Account.Session;

public interface ISessionStatsDomainService
{
   Task<List<SessionStats>> ViewSessionStats(string labLocation);
   
}
