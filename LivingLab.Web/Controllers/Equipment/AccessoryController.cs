using System.Diagnostics;

using LivingLab.Core.Entities.Identity;
using LivingLab.Web.Models.ViewModels;
using LivingLab.Web.Models.ViewModels.Accessory;
using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Device;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LivingLab.Web.Controllers.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
[Authorize(Roles = "Labtech")]
[Route("/Accessory")]
public class AccessoryController : Controller
{
    private readonly ILogger<AccessoryController> _logger;
    private readonly IAccessoryService _accessoryService;
    private readonly IDeviceService _deviceService;
    private readonly UserManager<ApplicationUser> _userManager;

    public AccessoryController(ILogger<AccessoryController> logger, IAccessoryService accessoryService, IDeviceService deviceService, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _accessoryService = accessoryService;
        _deviceService = deviceService;
        _userManager = userManager;
    }

    /// <summary>
    /// 1. Call accessory service to get all accessory according to the labLocation eg. NYP-SR7A and accessory type chosen
    /// </summary>
    /// <param name="accessoryType">accessory's type</param>
    /// <param name="labLocation">lab's location</param>
    /// <returns>ViewAccessoryViewModel</returns>
    [HttpPost("ViewAccessory")]
    public async Task<IActionResult> ViewAccessory(string accessoryType, string labLocation)
    {
        ViewAccessoryViewModel viewAccessories = await _accessoryService.ViewAccessory(accessoryType, labLocation);
        return View("ViewAccessory", viewAccessories);
    }

    /// <summary>
    /// 1. Call accessory service to get all accessory type according to the labLocation eg. NYP-SR7A
    /// </summary>
    /// <param name="labLocation">lab's location</param>
    /// <returns>ViewAccessoryTypeViewModel</returns>
    [Route("ViewAccessoryType/{labLocation}")]
    public async Task<IActionResult> ViewAccessoryType(string labLocation)
    {
        ViewAccessoryTypeViewModel viewAccessories = await _accessoryService.ViewAccessoryType(labLocation);
        return View("ViewAccessoryType", viewAccessories);
    }

    /// <summary>
    /// 1. Call accessory service to get all accessory details based on accessory Id
    /// </summary>
    /// <returns>AccessoryDetailsViewModel</returns>
    [Route("AddAccessoryDetails")]
    public async Task<AccessoryDetailsViewModel> AddAccessoryDetails()
    {
        //retrieve data from db
        AccessoryDetailsViewModel accessoryDetails = await _accessoryService.AddAccessoryDetails();
        return accessoryDetails;
    }

    /// <summary>
    /// 1. Call accessory service to edit an accessory to db
    /// </summary>
    /// <param name="id">accessory's id</param>
    /// <returns>AccessoryDetailsViewModel</returns>
    [Route("GetEditDetails/{id}")]
    public async Task<AccessoryDetailsViewModel> EditAccessoryDetails(int id)
    {
        //retrieve data from db
        AccessoryDetailsViewModel accessoryDetails = await _accessoryService.EditAccessoryDetails(id);
        return accessoryDetails;
    }

    /// <summary>
    /// 1. Call accessory service to get delete details such as accessory name etc
    /// </summary>
    /// <param name="id">accessory's id</param>
    /// <returns>AccessoryViewModel</returns>
    [Route("GetDeleteDetails/{id}")]
    public async Task<AccessoryViewModel> GetDeleteDetails(int id)
    {
        AccessoryViewModel accessoryViewModel = await _accessoryService.GetAccessory(id);
        return accessoryViewModel;
    }

    /// <summary>
    /// 1. Call accessory service to request approval for addition of accessory using email
    /// </summary>
    /// <param name="viewModel">accessory details view model</param>
    /// <returns></returns>
    [HttpGet]
    [HttpPost("CreateAccessory")]
    public async Task<IActionResult> CreateAccessory(AccessoryDetailsViewModel viewModel)
    {
        await _accessoryService.AddAccessory(viewModel);

        // Send email to labTech in charge for approval
        string scheme = this.Request.Scheme;
        string url = scheme + "://" + HostString.FromUriComponent("livinglab.amatsuka.me");
        var labTech = await _userManager.GetUserAsync(User);
        await _deviceService.SendReviewerEmail(url, viewModel.Accessory.Lab.LabLocation, labTech);

        return Redirect($"ViewAccessoryType/{viewModel.Accessory.Lab.LabLocation}");
    }

    /// <summary>
    /// 1. Call accessory service to edit accessory
    /// </summary>
    /// <param name="viewModel">accessory details view model</param>
    /// <returns>ViewAccessoryViewModel</returns>
    [HttpPost("EditAccessory")]
    public async Task<IActionResult> EditAccessory(AccessoryDetailsViewModel viewModel)
    {
        await _accessoryService.EditAccessory(viewModel);

        ViewAccessoryViewModel viewAccessory = await _accessoryService.ViewAccessory(viewModel.Accessory.AccessoryType.Type, viewModel.Accessory.Lab.LabLocation);
        return View("ViewAccessory", viewAccessory);
    }

    /// <summary>
    /// 1. Call accessory service to delete accessory
    /// </summary>
    /// <param name="deleteAccessory">accessory view model</param>
    /// <returns>ViewAccessoryViewModel</returns>
    [HttpPost("View/Delete")]
    public async Task<IActionResult> DeleteAccessory(AccessoryViewModel deleteAccessory)
    {
        await _accessoryService.DeleteAccessory(deleteAccessory);

        // Temp - To display ViewAll after editing
        ViewAccessoryViewModel viewAccessory = await _accessoryService.ViewAccessory(deleteAccessory.AccessoryType.Type, deleteAccessory.Lab.LabLocation);
        return View("ViewAccessory", viewAccessory);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
