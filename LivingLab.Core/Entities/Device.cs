using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
public class Device : BaseEntity
{
    [Required]
    public string DeviceSerialNumber { get; set; } = null!;
    [Required]
    // NOTE use one of the constants from LivingLab.Core.Constants.DeviceTypes
    public string Type { get; set; } = Constants.DeviceTypes.POWER_METER;
    public double? EnergyUsageThreshold { get; set; }
}
