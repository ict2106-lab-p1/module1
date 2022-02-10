using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class Todo : BaseEntity
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
}
