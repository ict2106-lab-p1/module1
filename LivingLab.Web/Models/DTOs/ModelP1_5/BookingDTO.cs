using Microsoft.Build.Framework;

namespace LivingLab.Web.Models.DTOs.ModelP1_5;

/// <summary>
/// You can group the models into folders if there are more than one
/// model required.
/// </summary>
public class BookingDTO
{
    public int bookingId { get; set; }
    public string startTime { get; set; }
    public string endTime { get; set; }
    public string startDate { get; set; }
    public string endDate { get; set; }
    public string labId { get; set; }
    public string description { get; set; }
}

/*
 * Structure for user to create a booking
 */
public struct BaseBookingDTO
{
    [Required]
    public string startTime { get; set; }
    [Required]
    public string endTime { get; set; }
    [Required]
    public string startDate { get; set; }
    [Required]
    public string endDate { get; set; }
    [Required]
    public string labId { get; set; }
    [Required]
    public string userId { get; set; }
    [Required]
    public string? description { get; set; }
}
