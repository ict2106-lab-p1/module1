using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.UIServices.LabBooking;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Lab;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingController : Controller
{
    private readonly ILabBookingService _labBookingService;

    private readonly ILogger<LabBookingController> _logger;

    private readonly UserManager<ApplicationUser> _usermanager;

    public LabBookingController(UserManager<ApplicationUser> usermanager, ILabBookingService labBookingService,
        ILogger<LabBookingController> logger)
    {
        _labBookingService = labBookingService;

        _logger = logger;

        _usermanager = usermanager;
        //Initalise labBooking service and usermanager which is used to get userid 
    }

    /// <summary>
    /// 1. User can see this page and register a new Booking
    /// 2. Navigate to a booking register form
    /// </summary>
    /// <param name="labid">Preset labid</param>
    /// <returns></returns>
    [Authorize]
    public IActionResult Register(int labid = 0)
    {
        BookFormModel newForm = new BookFormModel() { LabId = labid };

        return View("Register", newForm);
    }

    /// <summary>
    /// User,Admin and Labtech can see this Booking overview page
    /// getting the lab data from lab table in database as a list from labBookingservice 
    /// store the list in a variable of BookingManagementViewModel
    /// </summary>
    /// <param name="listOfBookings">BookingManagementViewModel consist of list of booking information</param>
    /// <returns>List of bookings</returns>
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpGet]
    public async Task<IActionResult> BookingsOverview(BookingManagementViewModel listOfBookings)
    {
        var getList = await _labBookingService.RetrieveList();
        listOfBookings.list = getList;
        return View("Index", listOfBookings);
    }

    /// <summary>
    /// User,Admin and Labtech can see this ViewAllBooking page which display the existed booking
    /// getting the book data from Booking table in database as a list from labBookingservice 
    /// store the list in a variable of BookingManagementViewModel
    /// </summary>
    /// <param name="listOfBookings">Model of booking management</param>
    /// <returns>Retrieve table of booking</returns>
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpGet]
    public async Task<IActionResult> ViewAllBookings(BookingTableManagementViewModel listOfBookings)
    {
        var getList = await _labBookingService.RetrieveBookTableList();
        listOfBookings.list = getList;

        return View("ViewBooking", listOfBookings);
    }


    /// <summary>
    /// Everyone can register a new booking
    /// get current user id from usermanager
    /// Call LabBookingservice function to create a book data in database
    /// </summary>
    /// <param name="labModel">Booking form to book lab</param>
    /// <returns>Successful booking message</returns>
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpPost]
    public async Task<IActionResult> BookRegister(BookFormModel labModel)
    {
        var user = await _usermanager.GetUserAsync(User);
        await _labBookingService.CreateBook(labModel, user.Id);
        return View("_CompleteBooking");
    }

    /// <summary>
    /// Delete lab booking for user
    /// call LabBookingservice to delete a row of book data with the same booking id as input of the function.
    /// navigate back to ViewBooking page after deletion is done.
    /// </summary>
    /// <param name="listOfBookings">Get list of the bookings</param>
    /// <param name="bookingid">Get booking id</param>
    /// <returns>Return view without the deleted booking item</returns>
    [Route("deletebooking/{bookingid}")]
    public async Task<IActionResult> DeleteBook(BookingTableManagementViewModel listOfBookings, int bookingid)
    {
        await _labBookingService.DeleteBook(bookingid);

        var getList = await _labBookingService.RetrieveBookTableList();
        listOfBookings.list = getList;

        return View("ViewBooking", listOfBookings);
    }
}
