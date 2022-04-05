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
public class LabBookingController: Controller
{
    private readonly ILabBookingService _labBookingService;
    
    private readonly ILogger<LabBookingController> _logger;

    private readonly UserManager<ApplicationUser> _usermanager;

    public LabBookingController(UserManager<ApplicationUser> usermanager, ILabBookingService labBookingService, ILogger<LabBookingController> logger)
    {
        _labBookingService = labBookingService;
       
        _logger = logger;

        _usermanager = usermanager;


    }
    [Authorize]
    /*Admin can see this page and register*/
    public IActionResult Register(int labid = 0)
    {
        BookFormModel newForm = new BookFormModel() {LabId = labid};
        return View("Register", newForm);
    }
    
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpGet]
    public async Task<IActionResult> BookingsOverview(BookingManagementViewModel listOfBookings)
    {    
         var getList = await _labBookingService.RetrieveList();
         listOfBookings.list = getList;
         return View("Index", listOfBookings);
    }
    
    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpGet]
    public async Task<IActionResult> ViewAllBookings(BookingTableManagementViewModel listOfBookings)
    {
         var getList = await _labBookingService.RetrieveBookTableList();
         listOfBookings.list = getList;
         _logger.LogInformation(listOfBookings.ToString());
         
        return View("ViewBooking", listOfBookings);
    }

    [Authorize(Roles = "User,Admin,Labtech")]
    [HttpPost]
       public async Task<IActionResult> BookRegister(BookFormModel labModel)
    {
        var user = await _usermanager.GetUserAsync(User);
            await _labBookingService.CreateBook(labModel, user.Id);
            return View("_CompleteBooking");
    }
        
       [Route("deletebooking/{bookingid}")]
         public async Task<IActionResult> DeleteBook(BookingTableManagementViewModel listOfBookings, int bookingid)
    {       
        await _labBookingService.DeleteBook(bookingid);
        var getList = await _labBookingService.RetrieveBookTableList();
        listOfBookings.list = getList;
        return View("ViewBooking", listOfBookings);
    }
    
}
