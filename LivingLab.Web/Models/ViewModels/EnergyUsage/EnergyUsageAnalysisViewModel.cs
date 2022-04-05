using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Web.Models.ViewModels.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>

public class EnergyUsageAnalysisViewModel
{
    public List<DeviceEnergyUsageDTO> DeviceEUList {get; set;}
    public List<LabEnergyUsageDTO> LabEUList {get; set;}
}
