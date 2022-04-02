using AutoMapper;

using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Web.Models.ViewModels.Booking;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.UIServices.LabProfile;

namespace LivingLab.Web.UIServices.LabBooking;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabBookingService : ILabBookingService
{
    private readonly  IMapper _mapper;
    private readonly ILabProfileDomainService _labProfileDomainService;
    private readonly IBookingDomainService _BookingDomainService;

    public LabBookingService(IMapper mapper, ILabProfileDomainService labProfileDomainService,IBookingDomainService BookingDomainService)
    {
        _mapper = mapper;
        _labProfileDomainService = labProfileDomainService;
        _BookingDomainService=BookingDomainService;
    }


    public async Task<List<BookingTableViewModel>> RetrieveBookTableList()
    {
                var listOfBooks = await _BookingDomainService.ViewBooks();
                    List<BookingTableViewModel> listOfBooking = new List<BookingTableViewModel>();
                 foreach (Booking Book in listOfBooks)
        {
            listOfBooking.Add(new BookingTableViewModel()
            {
                LabNo=Book.LabId,
                StartTime=Book.StartDateTime.ToString(),
                EndTime=Book.EndDateTime.ToString(),
                Description=Book.Description,
                BookId=Book.BookingId

                
            });
            Console.WriteLine(Book.BookingId);
        }
        
        return listOfBooking;
    }

    // public async Task<ViewDeviceViewModel> viewDevice()
    // {
    //     //retrieve data from db
    //     List<Core.Entities.Device> deviceList = await _deviceRepository.GetAllAsync();
    //             
    //     //map entity model to view model
    //     List<DeviceViewModel> devices = _mapper.Map<List<Core.Entities.Device>, List<DeviceViewModel>> (deviceList);
    //         
    //     //add list of device view model to the view device view model
    //     ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
    //     viewDevices.DeviceList = devices;
    //     return viewDevices;
    // }


    public async Task<List<BookingDashboardViewModel>> RetrieveList()
    {
        var listOfLabs = await _labProfileDomainService.ViewLabs();
        List<BookingDashboardViewModel> listOfLab = new List<BookingDashboardViewModel>();
        foreach (Lab lab in listOfLabs)
        {
            listOfLab.Add(new BookingDashboardViewModel()
            {
                LabNo = lab.LabId,
                LabCurrentUser = lab.Capacity,
                LabState = lab.LabStatus,
                LabLocation = lab.LabLocation
            });
            Console.WriteLine(lab.LabLocation);
        }

        return listOfLab;
    }

       public async Task<Booking?> CreateBook(BookFormModel Book, string userid)
    {
      var bookWrapper = new Booking
        {  
            StartDateTime = Book.StartTime,
            EndDateTime = Book.EndTime,
            Description=Book.Description,
            LabId = Book.LabId,
            UserId = userid
         
            // Area = labinput.Area,
            // Capacity = labinput.Capacity,
            // EnergyUsageBenchmark = labinput.EnergyUsageBenchmark
        };
        Console.WriteLine("Booking Services");
        return await _BookingDomainService.NewBook(bookWrapper);
    }

       public async Task<Booking?> DeleteBook(int bookid)
    {
      
            // Area = labinput.Area,
            // Capacity = labinput.Capacity,
            // EnergyUsageBenchmark = labinput.EnergyUsageBenchmark
   
        return await _BookingDomainService.DeleteBook(bookid);
    }
    
}
