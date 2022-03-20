using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.Accessory;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

public class AccessoryRepository : Repository<Accessory>, IAccessoryRepository
{
    private readonly ApplicationDbContext _context;

    public AccessoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Accessory>> GetAccessoryWithAccessoryType(string accessoryType)
    {
        // retrieve accessory table together with accessory type details using include to join entities 
        List <Accessory> accessories = await _context.Accessories.Include(a => a.AccessoryType)
            .Where(t => accessoryType.Contains(t.AccessoryType.Type))
            .ToListAsync();
        return accessories;
    }

    public async Task<Accessory> GetAccessory(int id)
    {
        return (await _context.Accessories.Include(a => a.AccessoryType).SingleOrDefaultAsync(a => a.Id == id))!;
    }


    public async Task<List<ViewAccessoryTypeDTO>> GetAccessoryType()
    {
        var accessoryGroup = await _context.Accessories.Include(a => a.AccessoryType)
            .GroupBy(t => t.AccessoryType!.Type)
            .Select(t=> new{Key = t.Key, Count = t.Count()})
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
        var accessory = await _context.Accessories.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
        return accessory;
    }
    public async Task<Accessory> DeleteAccessory(Accessory deleteAccessory)
    {
        // retrieve accessory db together with accessory type details using include to join entities
        Accessory currentAccessory = (await _context.Accessories.SingleOrDefaultAsync(d => d.Id == deleteAccessory.Id))!;
        _context.Accessories.Remove(currentAccessory);
        await _context.SaveChangesAsync();
        Console.WriteLine("Delete Succ");
        return deleteAccessory;
    }

    public async Task<AccessoryDetailsDTO> EditAccessory(AccessoryDetailsDTO accessoryDetailsDto)
    {
        Accessory accessory = (_context.Accessories.Include(d => d.AccessoryType)
            .SingleOrDefault(d => d.Id == accessoryDetailsDto.Accessory.Id))!;
        accessory.AccessoryType.Name = accessoryDetailsDto.Accessory.AccessoryType.Name;
        accessory.AccessoryType.Type = accessoryDetailsDto.Accessory.AccessoryType.Type;
        accessory.AccessoryType.Borrowable = accessoryDetailsDto.BorrowableValue == "1";
        accessory.DueDate = accessoryDetailsDto.Accessory.DueDate;
        await _context.SaveChangesAsync();
        return accessoryDetailsDto;
    }
}
