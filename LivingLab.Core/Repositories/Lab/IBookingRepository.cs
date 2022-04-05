using LivingLab.Core.Entities;

namespace LivingLab.Core.Repositories.Lab;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IBookingRepository : IRepository<Booking>
{
    Task<List<Booking>> GetAllBooking();
}


