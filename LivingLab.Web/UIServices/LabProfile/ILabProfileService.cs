using LivingLab.Core.Entities;
using LivingLab.Web.Models.ViewModels.LabProfile;

namespace LivingLab.Web.UIServices.LabProfile;




/// <summary>
/// Consist of Interfaces related to the Lab Profile such as the Individual Lab Profile Details,
/// All lab profile details, Lab Device available for Individual and the registration of lab accounts
/// </summary>
///
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
