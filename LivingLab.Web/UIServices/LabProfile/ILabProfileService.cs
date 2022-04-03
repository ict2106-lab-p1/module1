using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.Device;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public interface ILabProfileService
{
    Task<Lab?> GetLabProfileDetails(string labLocation);
    Task<List<LabInformationModel>?> GetAllLabAccounts();
    
    Task<List<string>> ViewDeviceType(string labLocation);
    
    Task<List<string>> ViewAccessoryType(string labLocation);
    Task<Lab?> NewLab(LabRegisterViewModel labinput);
}
