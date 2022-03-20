
using LivingLab.Core.Entities;

namespace LivingLab.Web.ApiModels;

public class AccessoryDTO
{
    public string? Status { get; set; }
    public DateTime LastUpdated { get; set; }
    public int LabId { get; set; }
    public int AccessoryTypeId { get; set; }
    public Lab? Lab { get; set; }
    public AccessoryType? AccessoryType { get; set; }
    public string? LabUserId { get; set; }
    public DateTime DueDate { get; set; }
}
