using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.UIServices.LabBooking;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabBookingService
{
    Task<List<BookingDashboardViewModel>> RetrieveList();
    Task<List<BookingTableViewModel>> RetrieveBookTableList();
    Task<Booking?> CreateBook(BookFormModel input, string userid);
    Task<Booking?> DeleteBook(int bookid);
}
