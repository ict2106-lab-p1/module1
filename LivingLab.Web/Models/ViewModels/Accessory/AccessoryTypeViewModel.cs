namespace LivingLab.Web.Models.ViewModels.Accessory;

public class AccessoryTypeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Borrowable { get; set; }
    public string? Description { get; set; }
}
