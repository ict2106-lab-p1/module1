using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageTrendSelectedLab
{
    public List<LabEnergyUsageDTO> GetEnergyUsageSelectedLab(DateTime start, DateTime end, int labId);
}