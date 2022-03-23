using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

using Microsoft.Extensions.Logging;

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
    private readonly ILabProfileRepository _labRepository;
    private readonly ILogger _logger;
    public LabProfileDomainService(ILabProfileRepository labRepository, ILogger<ILabProfileRepository> logger)
    {
        _labRepository = labRepository;
        _logger = logger;
    }    
    
    public Task<List<Lab>> ViewLabs()
    {
        return _labRepository.GetAllLabs();
    } 
 
    
    public Task<Lab> ViewLabDetails(int id)
    {
        return _labRepository.GetLabDetails(id);
    }
  
    /*Create new lab with lab details*/
    public async Task<Lab?> NewLab(Lab labinput)
    {
        return await _labRepository.AddAsync(labinput);
    }
}
