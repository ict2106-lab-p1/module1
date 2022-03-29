using LivingLab.Web.Models.ViewModels.Equipment;

namespace LivingLab.Web.UIServices.Equipment;

public interface IEquipmentService
{
    Task<EquipmentViewModel> ViewEquipment(string labLocation);
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus);
}
