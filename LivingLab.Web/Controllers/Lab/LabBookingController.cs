using LivingLab.Web.Controllers.Api;
using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.UIServices.LabBooking;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace LivingLab.Web.Controllers;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
[Route("labbooking")]
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
     [Route("register")]
    /*Admin can see this page and register*/
    public IActionResult Register()
    {
        return View("Register");
    }
    
    /*http://localhost:5051/labbooking/viewall*/
    [HttpGet]
    [Route("viewallLab")]
    public async Task<IActionResult> GetTableInfo(BookingManagementViewModel listOfBookings)
    {    
         _logger.LogInformation("You are in labbooking gettableinfo()");
         var getList = await _labBookingService.RetrieveList();
         listOfBookings.list = getList;
         _logger.LogInformation(listOfBookings.ToString());
         
        return View("Index", listOfBookings);
    }

    /*http://localhost:5051/labbooking/viewall*/
    [HttpGet]
    [Route("viewallBooking")]
    public async Task<IActionResult> GetTableInfo1(BookingTableManagementViewModel listOfBookings)
    {
         _logger.LogInformation("You are in booking gettableinfo1()");
         var getList = await _labBookingService.RetrieveBookTableList();
         listOfBookings.list = getList;
         _logger.LogInformation(listOfBookings.ToString());
         
        return View("ViewBooking", listOfBookings);
    }

    [HttpPost]
    [Route("addBooking")]
       public async Task<IActionResult> BookRegister(BookFormModel labModel)
    {
        Console.WriteLine("hello");
        var user = await _usermanager.GetUserAsync(User);
            await _labBookingService.CreateBook(labModel, user.Id);
            _logger.LogInformation("Test Successful");
            return View("Register", labModel);
    }
        
       [Route("deletebooking/{bookingid}")]
         public async Task<IActionResult> DeleteBook(BookingTableManagementViewModel listOfBookings, int bookingid)
    {       
        Console.WriteLine("hello here is controller");
        await _labBookingService.DeleteBook(bookingid);
        var getList = await _labBookingService.RetrieveBookTableList();
        listOfBookings.list = getList;
        return View("ViewBooking", listOfBookings);
    }
    
}
