namespace LivingLab.Web.Models.ViewModels.LabProfile;

public class LabInformationModel
{

    public int LabId { get; set; }
    
    public string? LabLocation { get; set; }
    
    public string? LabInCharge { get; set; }
    
    public string? LabStatus { get; set; }

    public int? Capacity { get; set; } = 0;

    public int? Occupied{ get; set; } = 0;

    public List<string> deviceNames { get; set; }
    
    public List<string> accessoriesNames { get; set; }
}
