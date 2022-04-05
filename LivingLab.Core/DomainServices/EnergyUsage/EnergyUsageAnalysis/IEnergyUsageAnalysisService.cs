using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageAnalysisService 
{
    public byte[] ExportDeviceEU(List<DeviceEnergyUsageDTO> DeviceEUList);
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end);

    // joey
    public List<TopSevenLabEnergyUsageDTO> GetTopSevenLabEnergyUsage(DateTime start, DateTime end);
    Task<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(EnergyUsageFilterDTO filter);
    Task<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(EnergyUsageFilterDTO filter);
    Task<Entities.Lab> GetLabEnergyBenchmark(int labId);


}
