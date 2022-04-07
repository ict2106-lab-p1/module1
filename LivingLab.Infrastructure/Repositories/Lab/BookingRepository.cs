using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Lab;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Lab;

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

    /// <summary>
    /// Retrieve lab bookings
    /// </summary>
    /// <returns>List of bookings</returns>
    public async Task<List<Booking>> GetAllBooking()
    {
        var labBooking = await _context.Bookings.ToListAsync();
        //extract all the Booking data from Book table
        return labBooking;
    }
}
