using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageComparisonService 
{
    //hy, the DTO have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs
    public List<DeviceEnergyUsageDTO> GetEnergyUsageByLabID(List<int> labIds, DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetEnergyUsageByDeviceType(List<string> deviceTYpe, DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab (int labId, DateTime start, DateTime end);
    public List<string> GetAllDeviceType();
    public List<string> GetAllLabLocation();
}