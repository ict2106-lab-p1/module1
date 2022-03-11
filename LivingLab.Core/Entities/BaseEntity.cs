using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
