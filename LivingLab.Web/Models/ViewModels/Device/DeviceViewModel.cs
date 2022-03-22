using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.Device;
/// <remarks>
/// Author: Team P1-3
/// </remarks>  
public class DeviceViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? SerialNo { get; set; }
    public Lab? Lab { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public double Threshold { get; set; }

    public string? ReviewStatus { get; set; }
    
    public string? ReviewedBy { get; set; }
    
    /*public List<DeviceTypeViewModel> ViewDeviceTypeDtos { get; set; }*/
}
