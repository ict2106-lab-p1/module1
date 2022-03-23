using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels.Equipment;

public class EquipmentViewModel
{
    public List<AccessoryViewModel> AccessoryViewModelList { get; set; }
    public List<DeviceViewModel> DeviceViewModelList { get; set; }
}
