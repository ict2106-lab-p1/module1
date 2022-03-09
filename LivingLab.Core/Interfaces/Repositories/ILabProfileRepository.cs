using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface ILabProfileRepository : IRepository<Lab>
{
    Task<List<Lab>?> GetAllLabProfile();
    Task<Lab?> AddLabProfile(Lab entry);
    Task<int> DeleteLabProfile(int labId);
}
