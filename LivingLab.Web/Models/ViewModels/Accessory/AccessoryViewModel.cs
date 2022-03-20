using LivingLab.Core.Entities;

namespace LivingLab.Web.Models.ViewModels.Accessory; 
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryViewModel
{
    public int Id { get; set; }
    public string? Status { get; set; }
    public DateTime LastUpdated { get; set; }
    public int LabId { get; set; }
    public int AccessoryTypeId { get; set; }
    public Lab? Lab { get; set; }
    public string? LabUserId { get; set; }
    public AccessoryType? AccessoryType { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    public string? ReviewStatus { get; set; }
    
    public string? ReviewedBy { get; set; }
}
