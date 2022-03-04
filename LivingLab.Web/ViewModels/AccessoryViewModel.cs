namespace LivingLab.Web.ViewModels;
    
using LivingLab.Domain.Entities;

public class AccessoryViewModel
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public DateTime LastUpdated { get; set; }

    public Lab? Lab { get; set; }
    public AccessoryType? AccessoryType { get; set; }
}
