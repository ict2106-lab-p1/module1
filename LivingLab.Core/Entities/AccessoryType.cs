using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class AccessoryType : BaseEntity
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public double? Cost { get; set; }

    [Required]
    public bool? Borrowable { get; set; }
    public string? Description { get; set; }
    public List<Accessory> Accessories { get; set; }
}
