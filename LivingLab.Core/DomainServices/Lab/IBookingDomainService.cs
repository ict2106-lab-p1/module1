using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.Lab;
/// <summary>
/// Interfaces for the domain services should
/// belong in this directory.
/// </summary>
/// 
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface IBookingDomainService
{
    Task<List<Booking>> ViewBooks();
    Task<Booking> NewBook(Booking book);
    Task<Booking> DeleteBook(int bookid);
}
