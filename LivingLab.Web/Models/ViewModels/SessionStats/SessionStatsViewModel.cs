using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.SessionStats;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class SessionStatsViewModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    
    public DateTime LoginTime { get; set; }
    
    public DateTime LogoutTime { get; set; }
    
    public Double DataUploaded { get; set; }
    
    public Lab? Lab { get; set; }
}
