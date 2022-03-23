using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.SessionStats;

public class SessionStatsViewModel
{
    public DateTime Date { get; set; }
    
    public DateTime LoginTime { get; set; }
    
    public DateTime LogoutTime { get; set; }
    
    public Double DataUploaded { get; set; }
    
    public Lab? Lab { get; set; }
}
