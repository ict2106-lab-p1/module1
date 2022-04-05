using LivingLab.Web.Models.ViewModels.UserManagement;

namespace LivingLab.Web.Models.ViewModels.Accessory;
/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryDetailsViewModel
{    
    public string? NewAccessoryType { get; set; }
    public string? BorrowableValue { get; set; }
    public AccessoryViewModel Accessory { get; set; }
    public List<AccessoryTypeViewModel> AccessoryTypes { get; set; }
    public List<UserManagementViewModel> UserList { get; set; }
}
