using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabAccess
{
    [Required]
    public string? UserId { get; set; }

    [Required]
    public int LabId { get; set; }
    
    [Required]
    public string? InitiatorId { get; set; }
    
    public ApplicationUser ApplicationUser { get; set; }
}
