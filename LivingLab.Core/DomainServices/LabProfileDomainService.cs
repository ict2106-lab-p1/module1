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
    private readonly ILabProfileRepository _labProfileRep;
    private readonly ILogger _logger;
    
    public LabProfileDomainService(ILabProfileRepository labProfileRep, ILogger<ILabProfileRepository> logger)
    {
        _labProfileRep = labProfileRep;
        _logger = logger;
    }
    public async Task<Lab?> NewLab(Lab labinput)
    {
        _logger.LogInformation("Henry add lab");
        return await _labProfileRep.AddAsync(labinput);
    }
}
