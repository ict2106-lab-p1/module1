using Microsoft.AspNetCore.Mvc.Rendering;

namespace LivingLab.Web.Models.ViewModels.Accessory; 
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class ViewAccessoryViewModel
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Borrowable { get; set; }
    public string? Description { get; set; }
    public int AccessoryTypeId { get; set; }

    public string? LabUserId { get; set; }
    public int? BorrowableIndex { get; set; }
    public string? newAccessoryType { get; set; }
    public List<SelectListItem> BorrowableList { get; set; }
    public List<SelectListItem> AccessoryTypeNameList { get; set; }
    public List<AccessoryViewModel> AccessoryList { get; set; }
}
