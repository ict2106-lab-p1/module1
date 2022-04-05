namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageFilterViewModel
{
    public int LabId { get; set; } = 1;
    public string LabLocation { get; set; } = "NYP-SR7C";
    public double EnergyUsage { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
}
