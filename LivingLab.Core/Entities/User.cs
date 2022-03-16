using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

public class User : BaseEntity
{
    public string Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string EncryptedPassword { get; set; }
    [Required]
    public string Faculty { get; set; }
    [Required]
    public string AuthenticationType { get; set; }
    [Required]
    public bool TwoFactorEnabled  { get; set; }
    [Required]
    public DateTime SMSExpiry { get; set; }
}
