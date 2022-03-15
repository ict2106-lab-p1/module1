using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;

namespace LivingLab.Core.DomainServices;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryDomainService : IAccessoryDomainService
{
    private readonly IAccessoryRepository _accessoryRepository;
    private readonly IAccessoryTypeRepository _accessoryTypeRepository;

    public AccessoryDomainService(IAccessoryRepository accessoryRepository, IAccessoryTypeRepository accessoryTypeRepository)
    {
        _accessoryRepository = accessoryRepository;
        _accessoryTypeRepository = accessoryTypeRepository;
    }
    
    public Task<List<Accessory>> ViewAccessory(string accessoryType)
    {
        return _accessoryRepository.GetAccessoryWithAccessoryType(accessoryType);
    }

    public Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType()
    {
        return _accessoryRepository.GetAccessoryType();
    }
    
    public Task<List<AccessoryType>> GetAllAsyncAccessoryType()
    {
        return _accessoryTypeRepository.GetAllAsync();
    }

    public Task<Accessory> GetAccessoryLastRow()
    {
        return _accessoryRepository.GetLastRow();
    }

    public async Task<Accessory> AddAccessory(Accessory accessory)
    {
        await _accessoryRepository.AddAsync(accessory);
        
        return accessory;
    }
}
