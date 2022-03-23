using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageEnergyIntensitySelectedLab
{
    public List<LabEnergyUsageDTO> GetEnergyUsageEnergyIntensitySelectedLab(DateTime start, DateTime end, int labId);
}