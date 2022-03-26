using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class TopSevenEnergyUsage : ITopSevenEnergyUsage
{
    public List<DeviceEnergyUsageDTO> GetEnergyUsageEachLab(DateTime star, DateTime end){
        throw new NotImplementedException();
    }
    public List<DeviceEnergyUsageDTO> SortEnergyUsageEachLab(int energyUsage){
        throw new NotImplementedException();
    }
    public List<DeviceEnergyUsageDTO> GetTopSevenEnergyUsage(){
        throw new NotImplementedException();
    }
}