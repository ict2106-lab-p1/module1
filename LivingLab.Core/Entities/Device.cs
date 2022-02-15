using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LivingLab.Domain.Entities;

public class Device : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
    public DateTime ValidityDate { get; set; }

    [Required]
    public string? SerialNo { get; set; }
    [Required]
    public Lab Lab { get; set; }
    [Required]
    public DeviceType DeviceType { get; set; }
}
