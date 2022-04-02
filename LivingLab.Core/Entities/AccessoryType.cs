using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryType
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }

    [Required]
    public bool Borrowable { get; set; }
    public string? Description { get; set; }
    
    public List<Accessory>? Accessories { get; set; }
    public static implicit operator AccessoryType(int v)
    {
        throw new NotImplementedException();
    }
}
