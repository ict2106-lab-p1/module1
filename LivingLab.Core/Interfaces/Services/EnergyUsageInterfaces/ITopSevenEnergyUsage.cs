using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface ITopSevenEnergyUsage
{
    public List<DeviceEnergyUsageDTO> GetEnergyUsageEachLab(DateTime star, DateTime end);
    public List<DeviceEnergyUsageDTO> SortEnergyUsageEachLab(int energyUsage);
    public List<DeviceEnergyUsageDTO> GetTopSevenEnergyUsage();
}