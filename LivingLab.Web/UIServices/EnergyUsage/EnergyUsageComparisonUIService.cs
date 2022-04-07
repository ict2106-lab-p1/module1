using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageComparison;
using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Web.UIServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageComparisonUIService : IEnergyUsageComparisonUIService
{

    private readonly IEnergyUsageComparisonService _comparison;

    public EnergyUsageComparisonUIService(IEnergyUsageComparisonService comparison)
    {
        _comparison = comparison;
    }

    /// <summary>
    /// Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonLabTableDTO</returns>
    public List<EnergyComparisonLabTableDTO> GetEnergyUsageByLabNameTable(string labName, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByLabNameTable(labName, start, end);
    }

    /// <summary>
    /// Retrieve device energy usage according to the deviceType, start and end date
    /// </summary>
    /// <param>devices type</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonDeviceTableDTO</returns>
    public List<EnergyComparisonDeviceTableDTO> GetEnergyUsageByDeviceType(string deviceType, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByDeviceType(deviceType, start, end);
    }

    /// <summary>
    /// Retrieve lab energy usage according to the labName, start and end date
    /// </summary>
    /// <param>lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>list of EnergyComparisonGraphDTO</returns>
    public List<EnergyComparisonGraphDTO> GetEnergyUsageByLabNameGraph(string labName, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByLabNameGraph(labName, start, end);
    }

    /// <summary>
    /// Retrieve energy usage benchmark for the lab according to the labName, start and end date
    /// </summary>
    /// <param>list of lab names</param>
    /// <param>start date</param>
    /// <param>end date</param>
    /// <returns>benchmark value</returns>
    public double GetEnergyUsageByLabNameBenchmark(string[] labNames, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByLabNameBenchmark(labNames, start, end);
    }

    /// <summary>
    /// Retrieve list of device types
    /// </summary>
    /// <returns>array list</returns>
    public List<string> GetAllDeviceType()
    {
        return _comparison.GetAllDeviceType();
    }

    /// <summary>
    /// Retrieve list of labs location
    /// </summary>
    /// <returns>array list</returns>
    public List<string> GetAllLabLocation()
    {
        return _comparison.GetAllLabLocation();
    }
}
