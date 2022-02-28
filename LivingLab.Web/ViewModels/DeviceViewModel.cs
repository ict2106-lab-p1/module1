namespace LivingLab.Web.ViewModels;
    
using LivingLab.Domain.Entities;
public class DeviceViewModel
{
    public int Id { get; set; }
    public DateTime ValidityDate { get; set; }

    public string? serialNo { get; set; }
    public Lab? Lab { get; set; }
    public DeviceType? DeviceType { get; set; }
}
