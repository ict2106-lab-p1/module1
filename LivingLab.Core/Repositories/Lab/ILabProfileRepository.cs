using LivingLab.Core.DomainServices.Lab;

namespace LivingLab.Core.Repositories.Lab;

/// <summary>
/// Consist of Interfaces for lab profile repository
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileRepository : IRepository<Entities.Lab>
{
    Task<LabProfileCollection> GetAllLabs();
    Task<Entities.Lab> GetLabDetails(int id);
    Task SetLabEnergyBenchmark(int labId, double energyBenchmark);
    Task<double> GetLabEnergyBenchmark(int labId);
    Task<Entities.Lab?> GetLabByLocation(string location);
    Task<List<Entities.Lab>> GetAllLabLocation();
}
