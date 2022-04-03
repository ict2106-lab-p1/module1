namespace LivingLab.Web.Models.ViewModels.LabProfile;

public class MultiModel
{
    public FormRegisterLabModel form { get; set; }
    public List<LabInformationModel> info { get; set; }
    
    public LabInformationModel eachlab { get; set; }
}
