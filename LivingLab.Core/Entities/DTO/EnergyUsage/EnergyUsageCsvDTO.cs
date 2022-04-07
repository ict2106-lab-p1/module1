namespace LivingLab.Core.Entities.DTO.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageCsvDTO
{
    public string? LabLocation { get; set; }

    public string? DeviceType { get; set; }

    public string? DeviceSerialNo { get; set; }

    public double EnergyUsage { get; set; }

    public int Interval { get; set; }

    public DateTime LoggedDate { get; set; }
}
