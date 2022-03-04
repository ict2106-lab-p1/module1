using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivingLab.Domain.Entities;

public class Device : BaseEntity
{
    [Required]
    [DataType(DataType.Date)]
    [Column(TypeName="Date")]
    public DateTime LastUpdated { get; set; }
    [Required]
    public string? SerialNo { get; set; }
    [Required]
    public Lab? Lab { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}
