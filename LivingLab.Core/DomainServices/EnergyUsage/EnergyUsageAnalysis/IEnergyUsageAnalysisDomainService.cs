using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;

/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageAnalysisDomainService
{
    public byte[] ExportDeviceEU(List<DeviceEnergyUsageDTO> DeviceEUList);
    public List<DeviceEnergyUsageDTO> GetDeviceEnergyUsageByDate(DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetLabEnergyUsageByDate(DateTime start, DateTime end);
    public Task<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(EnergyUsageFilterDTO filter);
    public Task<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(EnergyUsageFilterDTO filter);
    public Task<Entities.Lab> GetLabEnergyBenchmark(int labId);
}
