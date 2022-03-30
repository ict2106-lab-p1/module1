using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageComparisonService : IEnergyUsageComparisonService
{
    //hy, not sure what is your DTO, the DTO have to create in LivingLab.Core.Entities.DTO.EnergyUsageDTOs
    public List<DeviceEnergyUsageDTO> GetEnergyUsageByLabID(List<int> labIds, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    public List<LabEnergyUsageDTO> GetEnergyUsageByDeviceType(List<string> deviceTYpe, DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab (int labId, DateTime start, DateTime end)
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