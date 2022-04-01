using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;

namespace LivingLab.Core.Interfaces.Services;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryDomainService
{
    Task<List<Accessory>> ViewAccessory(string accessoryType, string labLocation);

    /***    
     * For P1-5 you can use this method below to populate the accessory list in the lab profile,
     * by injecting this IAccessoryDomainService in your UI's lab service.
     */
    Task<List<Accessory>> GetAccessoriesForLabProfile(string labLocation);
    void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus);
    
    // to use for reviewEquipment
    Task<List<Accessory>> GetAllAccessoriesForReview(string labLocation);
    Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType(string labLocation);
    
    Task<Accessory> AddAccessory(Accessory accessory);
    
    Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto);
    Task<Accessory> DeleteAccessory(Accessory deleteAccessory);
    Task<AccessoryDetailsDTO> AddAccessoryDetails();
    Task<Accessory> GetAccessory(int id);
    Task<AccessoryDetailsDTO> EditAccessoryDetails(int id);
}
