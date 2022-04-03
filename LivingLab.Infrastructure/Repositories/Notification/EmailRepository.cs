using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;
using LivingLab.Core.Repositories.Notification;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories.Notification;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EmailRepository : Repository<EmailLog>,IEmailRepository
{
    private readonly ApplicationDbContext _context;
    
    public EmailRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public Task<List<EmailLog>> GetEmailByStatus(string status)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmailLog>> GetEmailByDateRange(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
    
    public async Task<List<ApplicationUser>> GetAccountByNotiPref(NotificationType preference)
    {
        var technicianContacts = await _context.Users
            .Where(contacts => contacts.PreferredNotification == preference)
            .ToListAsync();
        return technicianContacts;
    }
}
