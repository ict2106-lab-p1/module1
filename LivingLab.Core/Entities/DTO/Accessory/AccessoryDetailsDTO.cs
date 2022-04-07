using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities.DTO.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryDetailsDTO
{
    public string? NewAccessoryType { get; set; }
    public string? BorrowableValue { get; set; }
    public Entities.Accessory? Accessory { get; set; }
    public List<AccessoryType>? AccessoryTypes { get; set; }
    public List<ApplicationUser>? UserList { get; set; }
}
