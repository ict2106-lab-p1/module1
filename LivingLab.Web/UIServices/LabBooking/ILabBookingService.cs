using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.Booking;

namespace LivingLab.Web.UIServices.LabBooking;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabBookingService
{
    Task<List<BookingDashboardViewModel>> RetrieveList();
    //retrieve the lab data from lab table as list
    Task<List<BookingTableViewModel>> RetrieveBookTableList();
    //retrieve the Book data from Book table as list
    Task<Booking?> CreateBook(BookingTableViewModel input, string userid);
    //Insert a new book data to book table in database
    Task<Booking?> DeleteBook(int bookid);
    //delete a exist book data in database
}
