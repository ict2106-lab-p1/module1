using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Domain.Entities;

public class Device : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName="Date")]
    public DateTime ValidityDate { get; set; }
    [Required]
    public string? SerialNo { get; set; }
    [Required]
    public int LabId { get; set; }
    [Required]
    public int DeviceTypeId { get; set; }
    public Lab? Lab { get; set; }
    public DeviceType? DeviceType { get; set; }
    

    // public string? Status { get; set; }
}
