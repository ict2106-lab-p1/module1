using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileDomainService: ILabProfileDomainService
{
    public readonly ILabProfileRepository _labRepository;
    
    //initialise repository 
    public LabProfileDomainService(ILabProfileRepository labRepository)
    {
        _labRepository = labRepository;
    }
    
    public Task<List<Lab>> ViewLabs()
    {
        return _labRepository.GetAllLabs();
    } 
 
    
    public Task<Lab> ViewLabDetails(int id)
    {
        return _labRepository.GetLabDetails(id);
    }
    
}
