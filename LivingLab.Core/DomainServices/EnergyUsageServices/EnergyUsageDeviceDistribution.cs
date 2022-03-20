using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageDeviceDistribution : IEnergyUsageDeviceDistribution
{
    public List<LabEnergyUsageDTO> GetDeviceAllLab(DateTime start, DateTime end, int deviceID)
    {
        throw new NotImplementedException();
    }
}