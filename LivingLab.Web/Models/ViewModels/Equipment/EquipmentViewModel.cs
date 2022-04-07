using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class EquipmentViewModel
{
    public List<AccessoryViewModel>? AccessoryViewModelList { get; set; }
    public List<DeviceViewModel>? DeviceViewModelList { get; set; }
}
