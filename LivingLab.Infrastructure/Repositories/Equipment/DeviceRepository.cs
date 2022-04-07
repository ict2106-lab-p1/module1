using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Device;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class DeviceRepository : Repository<Device>, IDeviceRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Get device based on serial Number
    /// </summary>
    /// <param name="serialNo"></param>
    /// <returns>device</returns>
    public async Task<Device> GetDeviceBySerialNo(string serialNo)
    {
        return await _context.Devices.FirstOrDefaultAsync(d => d.SerialNo == serialNo);
    }

    /// <summary>
    /// Function to get the list of devices based on lab location
    /// <param name="labLocation"></param>
    /// <returns>device</returns>
    /// </summary>
    public async Task<List<Device>> GetDevicesForLabProfile(string labLocation)
    {
        var device = await _context.Devices
            .Where(t => t.Status.ToLower().Equals("available")
                        && t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return device;
    }

    /// <summary>
    /// Function to update the device status based on device id and review status
    /// <param name="deviceId">string deviceId</param>
    /// <param name="deviceReviewStatus">string deviceReviewStatus</param>
    /// </summary>
    public async void UpdateDeviceStatus(string deviceId, string deviceReviewStatus)
    {
        Device device = (await _context.Devices.Where(d => d.Id == Convert.ToInt32(deviceId)).FirstOrDefaultAsync())!;
        if (device.ReviewStatus != deviceReviewStatus)
        {
            device.ReviewStatus = deviceReviewStatus;
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Function to get the list of devices for review based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns>device</returns>
    public async Task<List<Device>> GetAllDevicesForReview(string labLocation)
    {
        var device = await _context.Devices
            .Where(t => t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return device;
    }

    /// <summary>
    /// Function to get the list of devices type based on lab location
    /// </summary>
    /// <param name="labLocation"></param>
    /// <returns>deviceTypeDtos</returns>
    public async Task<DeviceCollection> GetViewDeviceType(string labLocation)
    {
        var deviceGroup = await _context.Devices
            .Include(l => l.Lab)
            .Where(l => l.Lab!.LabLocation == labLocation && l.ReviewStatus!.Equals("Approved"))
            .GroupBy(t => t.Type)
            .Select(t => new ViewDeviceTypeDTO { Type = t.Key, Quantity = t.Count() })
            .ToListAsync();

        var collection = new DeviceCollection();

        foreach (var device in deviceGroup)
        {
            collection.AddDevice(device);
        }

        return collection;
    }

    /// <summary>
    /// Function to get the list of devices based on lab location and device type
    /// </summary>
    /// <param name="deviceType">deviceType</param>
    /// <param name="labLocation">labLocation</param>
    /// <returns>deviceList</returns>
    public async Task<List<Device>> GetAllDevicesByType(string deviceType, string labLocation)
    {
        List<Device> deviceList = await _context.Devices
            .Include(l => l.Lab)
            .Where(t => deviceType.Contains(t.Type) && t.Lab!.LabLocation == labLocation && t.ReviewStatus!.Equals("Approved")).ToListAsync();
        return deviceList;
    }

    /// <summary>
    /// Get device details based on device id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>device</returns>
    public async Task<Device> GetDeviceDetails(int id)
    {
        // retrieve device db together with device type details using include to join entities
        Device device = (await _context.Devices
            .Include(l => l.Lab)
            .SingleOrDefaultAsync(d => d.Id == id))!;
        return device;
    }

    /// <summary>
    /// Get the device based on the last device id
    /// </summary>
    /// <returns></returns>
    public async Task<Device> GetLastRow()
    {
        var device = await _context.Devices
            .Include(l => l.Lab)
            .OrderByDescending(d => d.Id).FirstOrDefaultAsync();
        return device;
    }

    /// <summary>
    /// Function to add the device
    /// </summary>
    /// <param name="addedDevice"></param>
    /// <returns>addDevice</returns>
    public async Task<Device> AddDevice(Device addedDevice)
    {
        addedDevice.LabId = addedDevice.Lab.LabId;
        addedDevice.Lab = null;
        // add to database
        addedDevice.LastUpdated = DateTime.Today;
        addedDevice.ReviewStatus = "Pending";
        _context.Devices.Add(addedDevice);
        await _context.SaveChangesAsync();
        return addedDevice;
    }

    /// <summary>
    /// Function to update the device
    /// </summary>
    /// <param name="editedDevice"></param>
    /// <returns>editedDevice</returns>
    public async Task<Device> EditDeviceDetails(Device editedDevice)
    {
        // retrieve device db together with device type details using include to join entities
        Device currentDevice = (await _context.Devices.SingleOrDefaultAsync(d => d.Id == editedDevice.Id))!;
        currentDevice.SerialNo = editedDevice.SerialNo;
        currentDevice.Name = editedDevice.Name;
        currentDevice.Type = editedDevice.Type;
        currentDevice.Description = editedDevice.Description;
        currentDevice.Status = editedDevice.Status;
        currentDevice.Threshold = editedDevice.Threshold;
        currentDevice.LastUpdated = DateTime.Today;
        await _context.SaveChangesAsync();

        return editedDevice;
    }

    /// <summary>
    /// Function to delete the device
    /// </summary>
    /// <param name="deleteDevice"></param>
    /// <returns>deleteDevice</returns>
    public async Task<Device> DeleteDevice(Device deleteDevice)
    {
        // retrieve device db together with device type details using include to join entities
        Device currentDevice = (await _context.Devices.SingleOrDefaultAsync(d => d.Id == deleteDevice.Id))!;
        _context.Devices.Remove(currentDevice);
        await _context.SaveChangesAsync();
        Console.WriteLine("Delete Succ");
        return deleteDevice;
    }

    /// <summary>
    /// Function to get all devices type 
    /// </summary>
    /// <returns>device</returns>
    //Hong Ying
    public Task<List<Device>> GetAllDeviceType()
    {
        return IncludeReferences(
                _context.Devices
            )
            .ToListAsync();
    }

    /// <summary>
    /// Function to get unique device type 
    /// </summary>
    /// <returns>device</returns>
    public async Task<List<String>> GetDeviceTypes()
    {
        return (await _context.Devices
            .Select(t => t.Type)
            .Distinct()
            .ToListAsync());
    }

}
