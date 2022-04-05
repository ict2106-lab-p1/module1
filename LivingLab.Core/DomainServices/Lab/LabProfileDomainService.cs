using LivingLab.Core.Repositories.Lab;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Lab;
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
    
    public Task<List<Entities.Lab>> ViewLabs()
    {
        return _labRepository.GetAllLabs();
    }

    /*Create new lab with lab details*/
    public async Task<Entities.Lab?> NewLab(Entities.Lab labinput)
    {
        return await _labRepository.AddAsync(labinput);
    }

    public async Task<Entities.Lab> GetLabProfileDetails(string labLocation)
    {
        _logger.LogInformation("Get the lab info from lab : " + labLocation);
        return await _labRepository.GetLabByLocation(labLocation);
    }
}
