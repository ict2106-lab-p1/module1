using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Equipment;

public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<List<Accessory>> GetAccessoriesForLabProfile(string labLocation)
    {
        var accessories = await _context.Accessories
            .Where(t => t.Status == "Available"
                        && t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return accessories;
    }
    
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
    
    // to display in reviewEquipment
    public async Task<List<Accessory>> GetAllAccessoriesForReview(string labLocation)
    {
        var accessories = await _context.Accessories
            .Include(t => t.AccessoryType)
            .Where(t => t.Lab.LabLocation.Equals(labLocation))
            .ToListAsync();
        return accessories;
    }

    public async Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType, string labLocation)
    {
        // retrieve accessory table together with accessory type details using include to join entities 
        List<Accessory> accessories = await _context.Accessories
            .Include(l=>l.Lab)
            .Include(a => a.AccessoryType)
            .Where(t => accessoryType.Contains(t.AccessoryType!.Type) && t.Lab!.LabLocation==labLocation)
            .ToListAsync();
        return accessories;
    }

    public async Task<Accessory> GetAccessory(int id)
    {
        return (await _context.Accessories
            .Include(l => l.Lab)
            .Include(a => a.AccessoryType)
            .SingleOrDefaultAsync(a => a.Id == id))!;
    }
    public async Task<List<ViewAccessoryTypeDTO>> GetAccessoryType(string labLocation)
    {
        var accessoryGroup = await _context.Accessories
            .Include(l=>l.Lab)
            .Include(a => a.AccessoryType)
            .Where(l => l.Lab!.LabLocation == labLocation)
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
    
    public async Task<Accessory> GetLastRow()
    {
        var accessory = await _context.Accessories
            .Include(l=>l.Lab)    
            .OrderByDescending(a => a.Id).FirstOrDefaultAsync();
        return accessory;
    }
    public async Task<Accessory> DeleteAccessory(Accessory deleteAccessory)
    {
        // retrieve accessory db together with accessory type details using include to join entities
        Accessory currentAccessory = (await _context.Accessories.SingleOrDefaultAsync(d => d.Id == deleteAccessory.Id))!;
        _context.Accessories.Remove(currentAccessory);
        await _context.SaveChangesAsync();
        return deleteAccessory;
    }
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
