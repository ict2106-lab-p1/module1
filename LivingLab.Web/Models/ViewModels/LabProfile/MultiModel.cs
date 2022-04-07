namespace LivingLab.Web.Models.ViewModels.LabProfile;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class MultiModel
{
    public FormRegisterLabModel? form { get; set; }
    public List<LabInformationModel>? info { get; set; }

    public LabInformationModel? eachlab { get; set; }
}
