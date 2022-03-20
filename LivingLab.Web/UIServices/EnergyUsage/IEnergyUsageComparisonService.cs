using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Web.UIServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageComparisonService
{
    public List<DeviceEnergyUsageDTO> GetEnergyUsageByLabID(List<int> labIds, DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetEnergyUsageByDeviceType(List<string> deviceTYpe, DateTime start, DateTime end);
    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab (List<int> labIds, DateTime start, DateTime end);
    public List<string> GetAllDeviceType();
    public List<string> GetAllLabLocation();
}