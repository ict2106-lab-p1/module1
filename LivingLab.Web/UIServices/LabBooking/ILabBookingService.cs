using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.LabBooking;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabBookingService
{
    Task<ViewDeviceViewModel> viewDevice();
}
