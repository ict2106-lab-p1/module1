namespace LivingLab.Web.ViewModels;
    
using LivingLab.Domain.Entities;
public class DeviceViewModel
{
    public int Id { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? SerialNo { get; set; }
    public Lab? Lab { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double Threshold { get; set; } 
}
