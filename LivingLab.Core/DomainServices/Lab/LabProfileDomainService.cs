using LivingLab.Core.Repositories.Lab;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileDomainService : ILabProfileDomainService
{
    private readonly ILabProfileRepository _labRepository;
    private readonly ILogger _logger;
    public LabProfileDomainService(ILabProfileRepository labRepository, ILogger<ILabProfileRepository> logger)
    {
        _labRepository = labRepository;
        _logger = logger;
    }

    /// <summary>
    /// Get Lab Information of all labs
    /// </summary>
    /// <returns>List of Lab Information for all labs</returns>
    public Task<List<Entities.Lab>> ViewLabs()
    {
        return _labRepository.GetAllLabs();
    }

    /// <summary>
    /// Create new lab with lab details
    /// </summary>
    /// <param name="labinput">Lab</param>
    /// <returns>Lab</returns>
    public async Task<Entities.Lab?> NewLab(Entities.Lab labinput)
    {
        return await _labRepository.AddAsync(labinput);
    }

    /// <summary>
    /// Get lab information for individual labs by lab location
    /// </summary>
    /// <returns>Lab Information for individual labs by lab location</returns>
    public async Task<Entities.Lab> GetLabProfileDetails(string labLocation)
    {
        return await _labRepository.GetLabByLocation(labLocation);
    }
}
