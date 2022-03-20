using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;

namespace LivingLab.Core.Interfaces.Services;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryDomainService
{
    Task<List<Accessory>> ViewAccessory(string accessoryType);
    Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType();

    Task<Accessory> AddAccessory(Accessory accessory);
    Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto);
    Task<Accessory> DeleteAccessory(Accessory deleteAccessory);
    Task<AccessoryDetailsDTO> AddAccessoryDetails();
    Task<Accessory> GetAccessory(int id);
    Task<AccessoryDetailsDTO> EditAccessoryDetails(int id);
}
