namespace LivingLab.Core.Models;

public class EnergyUsageCsvModel
{
    public int DeviceId { get; set; }

    public string DeviceSerialNo { get; set; }

    public double EnergyUsage { get; set; }

    public double Duration { get; set; }

    public DateTime LoggedDate { get; set; }
}
