using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.Accessory; 

public class AccessoryViewModel
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public DateTime LastUpdated { get; set; }

    public Lab? Lab { get; set; }
    public AccessoryType? AccessoryType { get; set; }
}
