namespace LivingLab.Web.Models.ViewModels.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryTypeViewModel
{
    public int Id { get; set; }
    public string? Type { get; set; }
    public bool Borrowable { get; set; }
    public string? Description { get; set; }
}
