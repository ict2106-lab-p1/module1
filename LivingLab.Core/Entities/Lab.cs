using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
public class Lab : BaseEntity
{
    [Required]
    public double Area { get; set; }
}
