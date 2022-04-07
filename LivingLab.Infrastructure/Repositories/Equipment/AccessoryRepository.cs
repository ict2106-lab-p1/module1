using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Equipment;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    /// <summary>
    /// Gets all accessories
    /// <param name="labLocation">string labLocation</param>
    /// <returns>Accessories</returns>
    /// </summary>
    public async Task<List<Accessory>> GetAccessoriesForLabProfile(string labLocation)
    {
        var accessories = await _context.Accessories
            .Where(t => t.Status == "Available"
                        && t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return accessories;
    }
    /// <summary>
    /// <param name="accessoryId">string accessoryID</param>
    /// <param name="accessoryReviewStatus">string accessoryReviewStatus</param>
    /// </summary>
    public async void UpdateAccessoryStatus(string accessoryId, string accessoryReviewStatus)
    {
        Accessory accessory =
            (await _context.Accessories
                .Where(a => a.Id == Convert.ToInt32(accessoryId))
                .FirstOrDefaultAsync())!;
        if (accessory.ReviewStatus != accessoryReviewStatus)
        {
            accessory.ReviewStatus = accessoryReviewStatus;
        }
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Gets all accessories based on lab location to display in reviewEquipment
    /// </summary>
    /// <param name="labLocation">string labLocation</param>
    /// <returns></returns>
    public async Task<List<Accessory>> GetAllAccessoriesForReview(string labLocation)
    {
        var accessories = await _context.Accessories
            .Include(t => t.AccessoryType)
            .Where(t => t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return accessories;
    }

    /// <summary>
    /// Gets all accessories type based on lab location and accessory type.
    /// </summary>
    /// <param name="accessoryType">string accessoryType</param>
    /// <param name="labLocation">string labLocation</param>
    /// <returns></returns>
    public async Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType, string labLocation)
    {
        // retrieve accessory table together with accessory type details using include to join entities 
        List<Accessory> accessories = await _context.Accessories
            .Include(l => l.Lab)
            .Include(a => a.AccessoryType)
            .Where(t => accessoryType.Contains(t.AccessoryType!.Type) && t.Lab!.LabLocation == labLocation && t.ReviewStatus!.Equals("Approved"))
            .ToListAsync();
        return accessories;
    }
    /// <summary>
    /// Get Accessorye details based on ID
    /// </summary>
    /// <param name="id">int id</param>
    /// <returns></returns>
    public async Task<Accessory> GetAccessory(int id)
    {
        return (await _context.Accessories
            .Include(l => l.Lab)
            .Include(a => a.AccessoryType)
            .SingleOrDefaultAsync(a => a.Id == id))!;
    }
    /// <summary>
    /// Get accessory Type based on lab location
    /// </summary>
    /// <param name="labLocation">string lab location</param>
    /// <returns>accessoryTypeDtos</returns>
    public async Task<List<ViewAccessoryTypeDTO>> GetAccessoryType(string labLocation)
    {
        var accessoryGroup = await _context.Accessories
            .Include(l => l.Lab)
            .Include(a => a.AccessoryType)
            .Where(l => l.Lab!.LabLocation == labLocation && l.ReviewStatus!.Equals("Approved"))
            .GroupBy(t => t.AccessoryType!.Type)
            .Select(t => new { Key = t.Key, Count = t.Count() })
            .ToListAsync();
        List<ViewAccessoryTypeDTO> accessoryTypeDtos = new List<ViewAccessoryTypeDTO>();
        foreach (var group in accessoryGroup)
        {
            ViewAccessoryTypeDTO accessoryTypeDto = new ViewAccessoryTypeDTO();
            accessoryTypeDto.Type = group.Key;
            accessoryTypeDto.Quantity = group.Count;
            accessoryTypeDtos.Add(accessoryTypeDto);
        }
        return accessoryTypeDtos;
    }
    /// <summary>
    /// Get last row of the last accessory id
    /// </summary>
    /// <returns>accessory</returns>
    public async Task<Accessory> GetLastRow()
    {
        var accessory = await _context.Accessories
            .Include(l => l.Lab)
            .OrderByDescending(a => a.Id).FirstOrDefaultAsync();
        return accessory;
    }

    /// <summary>
    /// Delete accessory
    /// </summary>
    /// <param name="deleteAccessory"></param>
    /// <returns></returns>
    public async Task<Accessory> DeleteAccessory(Accessory deleteAccessory)
    {
        // retrieve accessory db together with accessory type details using include to join entities
        Accessory currentAccessory = (await _context.Accessories.SingleOrDefaultAsync(d => d.Id == deleteAccessory.Id))!;
        _context.Accessories.Remove(currentAccessory);
        await _context.SaveChangesAsync();
        return deleteAccessory;
    }
    /// <summary>
    ///  Function to update the accessory
    /// </summary>
    /// <param name="accessoryDetailsDto">AccessoryDetailsDTO accssoryDetailsDto</param>
    /// <returns>accessoryDetailsDto</returns>
    public async Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto)
    {
        Accessory accessory = (await _context.Accessories.Include(d => d.AccessoryType)
            .SingleOrDefaultAsync(d => d.Id == accessoryDetailsDto.Accessory.Id))!;
        // if (accessory.AccessoryType.Borrowable)
        accessory.AccessoryTypeId = accessoryDetailsDto.Accessory.AccessoryType.Id;
        accessory.Name = accessoryDetailsDto.Accessory.Name;
        accessory.AccessoryType.Borrowable = accessoryDetailsDto.Accessory.AccessoryType.Borrowable;
        accessory.LabUserId = accessoryDetailsDto.Accessory.LabUserId;
        accessory.DueDate = accessoryDetailsDto.Accessory.DueDate;
        accessory.AccessoryType.Description = accessoryDetailsDto.Accessory.AccessoryType.Description;
        accessory.Status = accessoryDetailsDto.Accessory.Status;
        await _context.SaveChangesAsync();
        return accessoryDetailsDto;
    }
}
