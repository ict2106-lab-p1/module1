using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingDomainService: IBookingDomainService
{
     private readonly IBookingRepository _BookingRepository;
    private readonly ILogger _logger;

      public BookingDomainService(IBookingRepository BookingRepository, ILogger<IBookingRepository> logger)
    {
        _BookingRepository = BookingRepository;
        _logger = logger;
    }

    public async Task<Booking> NewBook(Booking book)
    {
        Console.WriteLine("Booking Domain Services");
          return await _BookingRepository.AddAsync(book);
    }
    public Task<List<Booking>> ViewBooks()
    {
        return _BookingRepository.GetAllBooking();
    } 
      public async Task<Booking> DeleteBook(int bookid)
    {
        return await _BookingRepository.DeleteAsync(bookid);
    }

   
}
