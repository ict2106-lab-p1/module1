using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IAccessoryRepository : IRepository<Accessory>
{
    Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType);
    Task<List<ViewAccessoryTypeDTO>> GetAccessoryType();
}
