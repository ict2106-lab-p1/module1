using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IAccessoryRepository : IRepository<Accessory>
{
    Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType);
    Task<List<ViewAccessoryTypeDTO>> GetAccessoryType();
}
