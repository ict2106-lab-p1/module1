using System.Diagnostics;
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