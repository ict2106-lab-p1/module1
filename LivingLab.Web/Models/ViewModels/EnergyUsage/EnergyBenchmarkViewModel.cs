using System.ComponentModel.DataAnnotations;

using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyBenchmarkViewModel
{
    public int LabId { get; set; }
    
    [Display(Name = "Lab Energy Usage Benchmark")]
    public double EnergyUsageBenchmark { get; set; }
}
