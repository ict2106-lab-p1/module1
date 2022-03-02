namespace LivingLab.Web.ViewModels;
    
using LivingLab.Domain.Entities;
public class DeviceViewModel
{
    public int Id { get; set; }
    public DateTime ValidityDate { get; set; }

    public string? SerialNo { get; set; }
    public Lab? Lab { get; set; }
    public DeviceType? DeviceType { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }
    public string? Cost { get; set; }
}
