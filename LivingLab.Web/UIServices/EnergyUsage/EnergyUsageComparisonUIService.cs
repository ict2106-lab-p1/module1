using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
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

    public List<EnergyComparisonLabTableDTO> GetEnergyUsageByLabNameTable(string labName, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByLabNameTable(labName, start, end);   
    }
    public List<EnergyComparisonDeviceTableDTO> GetEnergyUsageByDeviceType(string deviceType, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByDeviceType(deviceType, start, end);
    }
    public List<EnergyComparisonGraphDTO> GetEnergyUsageByLabNameGraph(string labName, DateTime start, DateTime end)
    {
       return _comparison.GetEnergyUsageByLabNameGraph(labName, start, end);
    }

    public double GetEnergyUsageByLabNameBenchmark(string[] labNames, DateTime start, DateTime end)
    {
        return _comparison.GetEnergyUsageByLabNameBenchmark(labNames, start, end);
    }

    public List<string> GetAllDeviceType()
    {
        return _comparison.GetAllDeviceType();
    }
    public List<string> GetAllLabLocation()
    {
        return _comparison.GetAllLabLocation();
    }
}
