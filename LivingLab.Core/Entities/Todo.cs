using System.ComponentModel.DataAnnotations;

namespace LivingLab.Domain.Entities;

public class Todo : BaseEntity
{
    [Required]
    public string OTP {get; set; }
}
