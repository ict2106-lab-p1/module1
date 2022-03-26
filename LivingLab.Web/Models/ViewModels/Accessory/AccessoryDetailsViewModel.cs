namespace LivingLab.Web.Models.ViewModels.Accessory;

public class AccessoryDetailsViewModel
{    
    public string? NewAccessoryType { get; set; }
    public string? BorrowableValue { get; set; }
    public AccessoryViewModel Accessory { get; set; }
    public List<AccessoryTypeViewModel> AccessoryTypes { get; set; }
}
