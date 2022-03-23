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
    public Task<List<Accessory>> GetAccessoriesForLabProfile(string labLocation)
    {
        return _accessoryRepository.GetAccessoriesForLabProfile(labLocation);
    }

    public void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus)
    {
        _accessoryRepository.UpdateAccessoryStatus(accessoryId, accessoryReviewStatus);
    }

    public Task<List<Accessory>> GetAllAccessoriesForReview(string labLocation)
    {
        return _accessoryRepository.GetAllAccessoriesForReview(labLocation);
    }
    
    public Task<List<Accessory>> ViewAccessory(string accessoryType, string labLocation)
    {
        return _accessoryRepository.GetAccessoryWithAccessoryType(accessoryType, labLocation);
    }

    public Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType(string labLocation)
    {
        return _accessoryRepository.GetAccessoryType(labLocation);
    }
    
    public Task<List<AccessoryType>> GetAllAsyncAccessoryType()
    {
        return _accessoryTypeRepository.GetAllAsync();
    }

    public Task<Accessory> GetAccessoryLastRow()
    {
        return _accessoryRepository.GetLastRow();
    }

    public Task<Accessory> GetAccessory(int id)
    {
        return _accessoryRepository.GetAccessory(id);
    }

    public async Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto)
    {
        return await _accessoryRepository.EditAccessory(accessoryDetailsDto);
    }
    
    public async Task<AccessoryDetailsDTO> AddAccessoryDetails()
    {
        Accessory accessory = await _accessoryRepository.GetLastRow();
        List<AccessoryType> accessoryTypeList = await _accessoryTypeRepository.GetAllAsync();
        return new AccessoryDetailsDTO
        {
            Accessory = accessory, AccessoryTypes = accessoryTypeList
        };
    }

    public async Task<AccessoryDetailsDTO> EditAccessoryDetails(int id)
    {
        Accessory accessory = await _accessoryRepository.GetAccessory(id);
        List<AccessoryType> accessoryTypeList = await _accessoryTypeRepository.GetAllAsync();
        return new AccessoryDetailsDTO
        {
            Accessory = accessory, AccessoryTypes = accessoryTypeList
        };
    }

    public async Task<Accessory> AddAccessory(Accessory accessory)
    {
        await _accessoryRepository.AddAsync(accessory);
        
        return accessory;
    }
    
    
    
    public Task<Accessory> DeleteAccessory(Accessory deletedAccessory)
    {
        return _accessoryRepository.DeleteAccessory(deletedAccessory);
    }
}
