using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

public class Lab : BaseEntity
{
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? PersonInCharge { get; set; }
    [Required]
    public string? LabStatus { get; set; }
    public List<Logging>? Logs { get; set; }
    public List<Accessory>? Accessories { get; set; }
    public List<Device>? Devices { get; set; }
}
