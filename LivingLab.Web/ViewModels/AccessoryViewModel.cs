namespace LivingLab.Web.ViewModels;
    
using LivingLab.Domain.Entities;

public class AccessoryViewModel
{
    public int Id { get; set; }
    public string? status { get; set; }
    public DateTime ValidityDate { get; set; }

    public Lab? Lab { get; set; }
    public AccessoryType AccessoryType { get; set; }
}
