using System.Diagnostics;

using LivingLab.Web.ViewModels;
using LivingLab.Domain.Entities;
using LivingLab.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace LivingLab.Web.Controllers;

[Route("accessory")]
public class AccessoryController : Controller
{
    private readonly ILogger<AccessoryController> _logger;
    private readonly IMapper _mapper;
    private readonly IAccessoryRepository _accessoryRepository;

    public AccessoryController(ILogger<AccessoryController> logger, IMapper mapper, IAccessoryRepository accessoryRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _accessoryRepository = accessoryRepository;
    }

    [Route("view")]
    public async Task<IActionResult> ViewAccessory()
    {
        //retrieve data from db
        List<Accessory> accessoryList = await _accessoryRepository.GetAccessoryWithAccessoryType();

        //map entity model to view model
        List<AccessoryViewModel> accessories = _mapper.Map<List<Accessory>, List<AccessoryViewModel>>(accessoryList);

        //add list of accessory view model to the view accessory view model
        ViewAccessoryViewModel viewAccessories = new ViewAccessoryViewModel();
        viewAccessories.AccessoryList = accessories;
        return View("ViewAccessory", viewAccessories);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Accessory> accessoryList = await _accessoryRepository.GetAccessoryWithAccessoryType();
        return Ok(accessoryList);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}