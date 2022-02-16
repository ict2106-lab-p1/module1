using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class Lab : BaseEntity
{
    [Required]
    public string? Location { get; set; }
    [Required]
    public string? PersonInCharge { get; set; }
    [Required]
    public string? LabStatus { get; set; }
    public List<Report>? Reports { get; set; }
    public List<Accessory>? Accessories { get; set; }
    public List<Device>? Devices { get; set; }
}
