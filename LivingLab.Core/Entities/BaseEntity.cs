using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
