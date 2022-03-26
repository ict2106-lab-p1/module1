using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabProfileRepository : Repository<Lab>, ILabProfileRepository
{
    private readonly ApplicationDbContext _context;

    public LabProfileRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

  
    public async Task<List<Lab>> GetAllLabs()
    {
        var labGroup = await _context.LabProfile.ToListAsync();
        return labGroup;
    }
    public async Task<Lab> GetLabDetails(int id)
    {
        Lab user = (await _context.LabProfile.SingleOrDefaultAsync(d => d.LabId == id))!;
        return user;
    }
    
    // public async Task<Lab> EditUserDetail(Lab editUser)
    // {
    //     ApplicationUser currentUser = (await _context.LabProfile.SingleOrDefaultAsync(d => d.Id == editUser.Id))!;
    //     currentUser.Email = editUser.Email;
    //     currentUser.UserFaculty  = editUser.UserFaculty;
    //     currentUser.LabAccesses  = editUser.LabAccesses;
    //     await _context.SaveChangesAsync();       
    //     return editUser;
    // }
    // public async Task<Lab> DeleteAccount(Lab deleteUser)
    // {
    //     ApplicationUser currentUser = (await _context.LabProfile.SingleOrDefaultAsync(d => d.Id == deleteUser.Id))!;
    //     _context.Users.Remove(currentUser);
    //     await _context.SaveChangesAsync();
    //     return deleteUser;    
    // }
}
