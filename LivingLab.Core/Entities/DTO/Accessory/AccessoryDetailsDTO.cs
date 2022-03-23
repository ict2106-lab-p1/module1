namespace LivingLab.Core.Entities.DTO.Accessory;

public class AccessoryDetailsDTO
{
    public string? NewAccessoryType { get; set; }
    public string? BorrowableValue { get; set; }
    public Entities.Accessory Accessory { get; set; }
    public List<AccessoryType> AccessoryTypes { get; set; }
}
