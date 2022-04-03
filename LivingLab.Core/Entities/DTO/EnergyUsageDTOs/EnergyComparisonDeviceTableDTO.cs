namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;

public class EnergyComparisonDeviceTableDTO
{
    public string? DeviceType { get; set; }

    public double TotalEnergyUsage { get; set; }

    public double EnergyUsageCost { get; set; }
}
