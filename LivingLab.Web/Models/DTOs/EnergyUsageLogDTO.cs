namespace LivingLab.Web.Models.DTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogDTO
{
    public double EnergyUsage { get; set; }
    public double Interval { get; set; }
    public DateTime LoggedDate { get; set; } = DateTime.Now;
    public int LabId { get; set; }
    public string DeviceSerialNo { get; set; }
}
