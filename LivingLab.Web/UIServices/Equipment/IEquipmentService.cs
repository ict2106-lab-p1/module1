using LivingLab.Web.Models.ViewModels.Equipment;

namespace LivingLab.Web.UIServices.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public interface IEquipmentService
{
    Task<EquipmentViewModel> ViewEquipment(string labLocation);
    void UpdateDeviceStatus(string deviceId, string deviceReviewStatus);
    void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus);
}
