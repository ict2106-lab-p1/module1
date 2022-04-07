using System.ComponentModel.DataAnnotations;

using LivingLab.Core.Entities.Identity;

namespace LivingLab.Core.Entities;
/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDateTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDateTime { get; set; }

    public string? Description { get; set; }

    [Required]
    public int LabId { get; set; }

    public Lab? Lab { get; set; }

    [Required]
    public string? UserId { get; set; }

    public ApplicationUser? ApplicationUser { get; set; }

}

