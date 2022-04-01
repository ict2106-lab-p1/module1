using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileRepository : IRepository<Lab>
{
    Task<List<Lab>> GetAllLabs();
    Task<Lab> GetLabDetails(int id);
    Task SetLabEnergyBenchmark(int labId, double energyBenchmark);
    Task<double> GetLabEnergyBenchmark(int labId);

    Task<Lab> GetLabByLocation(string location);
}
