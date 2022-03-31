using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;

namespace LivingLab.Core.DomainServices;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>

/// </remarks>
public class LivingLabDashboardDomainService: ILivingLabDashboardDomainService
{

    public readonly ILabProfileRepository _labRepository;
    public LivingLabDashboardDomainService(ILabProfileRepository labRepository)
    {
        _labRepository = labRepository;
    }
    public Task<List<Lab>> ViewLabs()
    {
        return _labRepository.GetAllLabs();
    } 

}
