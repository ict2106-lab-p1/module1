using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

public class Todo : BaseEntity
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
}
