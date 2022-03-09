using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Enums;

namespace LivingLab.Core.Entities;

public class EmailLog: BaseEntity
{
    public string Message { get; set; } = "";
    public string Subject { get; set; } = "";
    public MessageStatus Status { get; set; }
    public DateTime LoggedDate { get; set; }
    public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
