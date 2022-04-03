namespace LivingLab.Core.Repositories.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileRepository : IRepository<Entities.Lab>
{
    Task<List<Entities.Lab>> GetAllLabs();
    Task<Entities.Lab> GetLabDetails(int id);
    Task SetLabEnergyBenchmark(int labId, double energyBenchmark);
    Task<double> GetLabEnergyBenchmark(int labId);
    Task<Entities.Lab> GetLabByLocation(string location);
    Task<Entities.Lab> GetLabProfileDetails(string labLocation);
    Task<List<Entities.Lab>> GetAllLabLocation();
}
