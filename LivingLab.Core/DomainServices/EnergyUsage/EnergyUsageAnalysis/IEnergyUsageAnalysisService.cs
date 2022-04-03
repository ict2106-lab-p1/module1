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
    // public List<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(DateTime start, DateTime end);
    Task<IndividualLabMonthlyEnergyUsageDTO> GetEnergyUsageTrendSelectedLab(EnergyUsageFilterDTO filter);
    Task<MonthlyEnergyUsageDTO> GetEnergyUsageTrendAllLab(EnergyUsageFilterDTO filter);
    
    // JOEY ADDED
    Task<Entities.Lab> GetLabEnergyBenchmark(int labId);

    // weijie
    // not sure what will be your DTO looks like may have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
    public List<DeviceInLabDTO> GetEnergyUsageLabDistribution(DateTime start, DateTime end, int labId);
    public List<DeviceInLabDTO> GetEnergyUsageDeviceDistribution(DateTime start, DateTime end, string deviceType);


}
