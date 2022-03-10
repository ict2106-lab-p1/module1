using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Services;

public interface IAccessoryDomainService
{
    Task<List<Accessory>> ViewAccessory(string accessoryType);
    Task<List<ViewAccessoryTypeDTO>> ViewAccessoryType();
}
