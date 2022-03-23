using LivingLab.Web.Models.ViewModels.Equipment;

namespace LivingLab.Web.UIServices.Equipment;

public interface IEquipmentService
{
    Task<EquipmentViewModel> ViewEquipment(string labLocation);
}
