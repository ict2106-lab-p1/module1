namespace LivingLab.Core.Models;

public class EnergyUsageCsvModel
{
    public string? DeviceSerialNo { get; set; }

    public double EnergyUsage { get; set; }

    public int Interval { get; set; }

    public DateTime LoggedDate { get; set; }
}
