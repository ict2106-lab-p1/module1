using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
