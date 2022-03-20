using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageDeviceDistribution
{
    public List<LabEnergyUsageDTO> GetDeviceAllLab(DateTime start, DateTime end, int deviceID);
}