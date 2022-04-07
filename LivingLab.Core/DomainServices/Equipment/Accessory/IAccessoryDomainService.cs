using LivingLab.Core.Entities.DTO.Accessory;

namespace LivingLab.Core.DomainServices.Equipment.Accessory;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IAccessoryDomainService
{
    Task<List<Entities.Accessory>> ViewAccessory(string accessoryType, string labLocation);

    Task<List<Entities.Accessory>> GetAccessoriesForLabProfile(string labLocation);
    void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus);

    Task<List<Entities.Accessory>> GetAllAccessoriesForReview(string labLocation);

    Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType(string labLocation);

    Task<Entities.Accessory> AddAccessory(Entities.Accessory accessory);

    Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto);

    Task<Entities.Accessory> DeleteAccessory(Entities.Accessory deleteAccessory);
    Task<AccessoryDetailsDTO> AddAccessoryDetails();
    Task<Entities.Accessory> GetAccessory(int id);

    Task<AccessoryDetailsDTO> EditAccessoryDetails(int id);
}
