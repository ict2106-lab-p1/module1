using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageTrendAllLab
{
    public List<LabEnergyUsageDTO> GetEnergyUsageAllLab(DateTime start, DateTime end);
}