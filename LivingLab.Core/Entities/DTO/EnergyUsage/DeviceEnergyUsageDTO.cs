namespace LivingLab.Core.Entities.DTO.EnergyUsage;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class DeviceEnergyUsageDTO 
{
    public string? DeviceSerialNo { get; set; }

    public string? DeviceType { get; set;}

    public double TotalEnergyUsage { get; set;}

    public double EnergyUsageCost { get; set;}
}
