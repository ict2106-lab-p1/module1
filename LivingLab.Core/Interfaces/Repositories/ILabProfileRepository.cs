using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileRepository : IRepository<Lab>
{
    Task<List<Lab>?> GetAllLabProfile();
    Task<Lab?> AddLabProfile(Lab entry);
    Task<int> DeleteLabProfile(int labId);
}
