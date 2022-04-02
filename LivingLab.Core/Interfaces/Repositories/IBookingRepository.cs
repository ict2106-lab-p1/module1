using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IBookingRepository : IRepository<Booking>
{
    Task<List<Booking>> GetAllBooking();
    Task<Booking?> AddBooking(Booking booking);
    Task<int> DeleteBooking(int bookingId);
}


