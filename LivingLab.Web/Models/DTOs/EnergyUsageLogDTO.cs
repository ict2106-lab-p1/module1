using Newtonsoft.Json;

namespace LivingLab.Web.Models.DTOs;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogDTO
{
    [JsonProperty("lab_location")]
    public string LabLocation { get; set; }
    [JsonProperty("energy_usage")]
    public double EnergyUsage { get; set; }
    [JsonProperty("interval")]
    public double Interval { get; set; }
    [JsonProperty("logged_at")]
    public DateTime LoggedDate { get; set; } = DateTime.Now;
    [JsonProperty("device_serial_no")]
    public string DeviceSerialNo { get; set; }
}
