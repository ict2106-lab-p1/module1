using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Services;

public interface ISessionStatsDomainService
{
   Task<List<SessionStats>> ViewSessionStats();
}
