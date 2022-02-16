using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class DeviceType : BaseEntity
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public double? Cost { get; set; }
    public List<Device>? Devices { get; set; }

    public static implicit operator DeviceType(int v)
    {
        throw new NotImplementedException();
    }
}
