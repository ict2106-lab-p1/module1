using LivingLab.Domain.Entities;

namespace LivingLab.Domain.Interfaces.Repositories;

public interface IAccessoryRepository : IRepository<Accessory>
{
    Task<List<Accessory>> GetAccessoryWithAccessoryType();
}
