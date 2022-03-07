
namespace LivingLab.Domain.Entities;
using Microsoft.Build.Framework;


public class DeviceDTO
{
    public DateTime LastUpdated { get; set; }
    public string? SerialNo { get; set; }
    public Lab Lab { get; set; }
    public string Status { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
