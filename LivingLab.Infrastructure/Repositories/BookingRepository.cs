namespace LivingLab.Infrastructure.Repositories;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingRepository : Repository<Booking>, IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Booking>?> GetAllBooking()
    {
        throw new NotImplementedException();
    }

    public async Task<Booking> AddBooking(Booking booking)
    {
        //Return booking that is stored
        throw new NotImplementedException();
    }
    
    public async Task<int> DeleteBooking(int bookingId)
    {
        throw new NotImplementedException();
    }
}
