using System.Diagnostics;
<<<<<<< HEAD
using LivingLab.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers;

public class DeviceController : Controller
{
    public IActionResult ViewDevice()
    {
        var lab = new Lab() { Name = "NYP-SR7C" };
        var devices = new List<Device> 
        { 
            new Device { 
                Id = 1,
                Name = "Sensors", 
                Desc = "To measure temp humidity vibration", 
                Serial = "S-1001", 
                Cost = "$100", 
                Qty=10 
                },
            new Device { 
                Id = 2,
                Name = "Robots", 
                Desc = "Follow researcher around labs", 
                Serial = "S-1002", 
                Cost = "$10,000", 
                Qty=2 
                }
        };

        var viewModel = new DeviceViewModel 
        {
            Lab = lab,
            Devices = devices
        };
        return View(viewModel);
    }

}
=======

using LivingLab.Web.ViewModels;

using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace LivingLab.Web.Controllers;

[Route("device")]
public class DeviceController : Controller
{
    private readonly ILogger<DeviceController> _logger;
    private readonly  IMapper _mapper;
    private readonly IDeviceRepository _deviceRepository;


    public DeviceController(ILogger<DeviceController> logger, IMapper mapper, IDeviceRepository deviceRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _deviceRepository = deviceRepository;
    }

    [Route("view")]
    public async Task<IActionResult> ViewDevice()
    { 
        //retrieve data from db
        List<Device> deviceList = await _deviceRepository.GetDeviceWithDeviceType();
        
        //map entity model to view model
        List<DeviceViewModel> devices = _mapper.Map<List<Device>, List<DeviceViewModel>> (deviceList);
        
        //add list of device view model to the view device view model
        ViewDeviceViewModel viewDevices = new ViewDeviceViewModel();
        viewDevices.DeviceList = devices;
        return View("ViewDevice", viewDevices);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Device> deviceList = await _deviceRepository.GetDeviceWithDeviceType();
        return Ok(deviceList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
>>>>>>> 7177fb045fda2cf42579f6e724d0b614b71063e4
