using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileService
{
    Task<ViewLabProfileViewModel> GetAllLabAccounts();
    
   Task<LabProfileViewModel> ViewLabDetails(int id);

}
