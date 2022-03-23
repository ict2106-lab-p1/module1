using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;
using LivingLab.Core.Entities.DTO.Accessory;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryRepository : IRepository<Accessory>
{
    Task<List<Accessory>> GetAccessoriesForLabProfile(string labLocation);
    Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType, string labLocation);
    Task<List<ViewAccessoryTypeDTO>> GetAccessoryType(string labLocation);
    Task<Accessory> GetLastRow();
    
    Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto);
    Task<Accessory> DeleteAccessory(Accessory deletedAccessory);
    Task<Accessory> GetAccessory(int id);
}
