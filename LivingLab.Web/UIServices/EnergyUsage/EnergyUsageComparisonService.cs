using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Web.UIServices.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageComparisonService : IEnergyUsageComparisonService 
{
    public List<DeviceEnergyUsageDTO> GetEnergyUsageByLabID(List<int> labIds, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    public List<LabEnergyUsageDTO> GetEnergyUsageByDeviceType(List<string> deviceTYpe, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab (List<int> labIds, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    public List<string> GetAllDeviceType()
    {
        throw new NotImplementedException();
    }
    public List<string> GetAllLabLocation()
    {
        throw new NotImplementedException();
    }
}