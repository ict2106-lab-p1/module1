using LivingLab.Core.Entities;

namespace LivingLab.Core.Interfaces.Repositories;

public interface IBookingRepository : IRepository<Booking>
{
    Task<List<Booking>?> GetAllBooking();
    Task<Booking?> AddBooking(Booking booking);
    Task<int> DeleteBooking(int bookingId);
}


