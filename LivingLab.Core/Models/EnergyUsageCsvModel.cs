namespace LivingLab.Core.Models;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageCsvModel
{
    public string? DeviceSerialNo { get; set; }

    public double EnergyUsage { get; set; }

    public int Interval { get; set; }

    public DateTime LoggedDate { get; set; }
}
