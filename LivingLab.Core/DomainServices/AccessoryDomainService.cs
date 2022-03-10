using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryDomainService : IAccessoryDomainService
{
    private readonly IAccessoryRepository _accessoryRepository;

    public AccessoryDomainService(IAccessoryRepository accessoryRepository)
    {
        _accessoryRepository = accessoryRepository;
    }
    
    public Task<List<Accessory>> ViewAccessory(string accessoryType)
    {
        return _accessoryRepository.GetAccessoryWithAccessoryType(accessoryType);
    }

    public Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType()
    {
        return _accessoryRepository.GetAccessoryType();
    }
}
