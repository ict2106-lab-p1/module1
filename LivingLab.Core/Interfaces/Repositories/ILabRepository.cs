using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface ILabRepository : IRepository<Lab>
{
    Task SetLabEnergyBenchmark(int labId, double energyBenchmark);
    Task<double> GetLabEnergyBenchmark(int labId);

    Task<List<Lab>> GetAllLabLocation();
    Task<List<Lab>> GetAllLabs();
}
