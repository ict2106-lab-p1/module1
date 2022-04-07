using LivingLab.Core.Entities;
using LivingLab.Core.Repositories.Lab;

using Microsoft.Extensions.Logging;

namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Domain service implementations belongs here.
/// Domain service are classes that are responsible for business logic.
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingDomainService : IBookingDomainService
{
    private readonly IBookingRepository _BookingRepository;
    private readonly ILogger _logger;

    public BookingDomainService(IBookingRepository BookingRepository, ILogger<IBookingRepository> logger)
    {
        //Initalise Booking repository
        _BookingRepository = BookingRepository;
        _logger = logger;
    }
    /// <summary>
    /// Function to Insert new booking data
    /// </summary>
    /// <param name="book">Booking data object</param>
    /// <returns></returns>
    public async Task<Booking> NewBook(Booking book)
    {
        Console.WriteLine("Booking Domain Services");
        return await _BookingRepository.AddAsync(book);
        //Using function of Repository class to add Book
    }


    /// <summary>
    /// 1. Call Booking repo to get all book data
    /// </summary>
    /// <returns>Booking</returns>
    public Task<List<Booking>> ViewBooks()
    {
        return _BookingRepository.GetAllBooking();
        //Retrieve all the database of booking in book table
    }

    /// <summary>
    /// Function to delete booking by their bookid
    /// </summary>
    /// <param name="bookid">Lab booking id</param>
    /// <returns></returns>
    public async Task<Booking> DeleteBook(int bookid)
    {
        return await _BookingRepository.DeleteAsync(bookid);
        //delete book with the input bookid
    }


}
