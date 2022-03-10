namespace LivingLab.Core.Models;

public class DeviceEnergyUsageModel
{
    public string? DeviceSerialNo { get; set; }

    public string? DeviceType { get; set;}

    public int? TotalEnergyUsage { get; set;}

    public int? EnergyUsagePerHour { get; set;}

    public double EnergyUsageCost { get; set;}
}
